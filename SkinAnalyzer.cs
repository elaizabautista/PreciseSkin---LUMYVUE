using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace PreciseSkin___LUMYVUE
{
    public class SkinAnalysisResult
    {
        public string ConditionPrediction { get; set; }
        public string SkinTypePrediction { get; set; }
    }

    public class SkinAnalyzer
    {
        private readonly InferenceSession _onnxSession;

        // 🎯 Your exact target skin conditions matched to Kaggle's internal index array order!
        // Index 0 = Acne, Index 1 = Eczema, Index 2 = Hyperpigmentation
        private readonly string[] _diseaseLabels = {
            "Acne and Rosacea",
            "Eczema",
            "Hyperpigmentation"
        };

        public SkinAnalyzer()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string modelPath = Path.Combine(baseDir, "Assets", "PreciseSkin_Model.onnx");

            if (!File.Exists(modelPath))
            {
                modelPath = Path.Combine(baseDir, "PreciseSkin_Model.onnx");
            }

            if (File.Exists(modelPath))
            {
                _onnxSession = new InferenceSession(modelPath);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Critical Error: Could not find 'PreciseSkin_Model.onnx' file!\nChecked location: {modelPath}\n\nMake sure to put your downloaded model file into your Assets folder!",
                    "Missing Model File"
                );
            }
        }

        public SkinAnalysisResult AnalyzeImage(string imagePath)
        {
            if (_onnxSession == null)
            {
                return new SkinAnalysisResult { ConditionPrediction = "Engine Error", SkinTypePrediction = "N/A" };
            }

            DenseTensor<float> inputTensor = PreprocessImage(imagePath);

            var inputs = new List<NamedOnnxValue>
    {
        NamedOnnxValue.CreateFromTensor("input_image", inputTensor)
    };

            using (IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = _onnxSession.Run(inputs))
            {
                var outputsList = results.ToList();
                var targetOutput = outputsList.FirstOrDefault(o => o.Name == "skin_condition_output") ?? outputsList[0];

                float[] conditionScores = targetOutput.AsEnumerable<float>().ToArray();

                // Find the array index with the highest probability value
                int highestIndex = 0;
                float highestScore = -1f;

                for (int i = 0; i < conditionScores.Length; i++)
                {
                    if (conditionScores[i] > highestScore)
                    {
                        highestScore = conditionScores[i];
                        highestIndex = i;
                    }
                }

                string predictedCondition = _diseaseLabels[highestIndex];

                // 🎯 EMERGENCY READOUT: Show the raw scoring numbers right on the UI!
                // This will tell us if the numbers are shifting or completely locked.
                string rawScoresLog = $"Raw Output -> [0]: {conditionScores[0]:F4} | [1]: {conditionScores[1]:F4} | [2]: {conditionScores[2]:F4}";

                return new SkinAnalysisResult
                {
                    ConditionPrediction = $"{predictedCondition} ({highestScore:P1})",
                    SkinTypePrediction = rawScoresLog // This will print your raw numbers onto the results form text area!
                };
            }
        }

        private DenseTensor<float> PreprocessImage(string path)
        {
            using (System.Drawing.Bitmap rawBitmap = new System.Drawing.Bitmap(path))
            using (System.Drawing.Bitmap resizedBitmap = new System.Drawing.Bitmap(rawBitmap, new System.Drawing.Size(224, 224)))
            {
                // 🎯 Set up a 4D tensor matching [Batch=1, Height=224, Width=224, Channels=3]
                var tensor = new DenseTensor<float>(new[] { 1, 224, 224, 3 });

                for (int y = 0; y < 224; y++)
                {
                    for (int x = 0; x < 224; x++)
                    {
                        System.Drawing.Color pixel = resizedBitmap.GetPixel(x, y);

                        // 🎯 Lock the index values to explicit coordinates to feed the network correctly
                        tensor[0, y, x, 0] = (pixel.R / 127.5f) - 1f;
                        tensor[0, y, x, 1] = (pixel.G / 127.5f) - 1f;
                        tensor[0, y, x, 2] = (pixel.B / 127.5f) - 1f;
                    }
                }
                return tensor;
            }
        }
    }
}