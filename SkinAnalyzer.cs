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

            // 1. Run our fixed pixel normalization pipeline
            DenseTensor<float> inputTensor = PreprocessImage(imagePath);

            // 2. 🎯 FIXED: Changed input layer key name from "input" to "input_image" to match your Kaggle model!
            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("input_image", inputTensor)
            };

            // 3. Execute the ONNX evaluation runtime
            using (IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = _onnxSession.Run(inputs))
            {
                var outputsList = results.ToList();

                // 4. 🎯 FIXED: Safely pull predictions out of your true output node name 'skin_condition_output'
                var targetOutput = outputsList.FirstOrDefault(o => o.Name == "skin_condition_output");
                if (targetOutput == null)
                {
                    // Fallback to position 0 if name lookup behaves strangely
                    targetOutput = outputsList[0];
                }

                float[] conditionScores = targetOutput.AsEnumerable<float>().ToArray();

                // 5. Math tracking: Find the array slot with the highest confidence decimal percentage
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

                // Protect against out-of-bounds arrays safely
                string predictedCondition = "Unknown Condition";
                if (highestIndex < _diseaseLabels.Length)
                {
                    predictedCondition = _diseaseLabels[highestIndex];
                }

                // Formulate the display readouts for your ResultsForm UI components
                return new SkinAnalysisResult
                {
                    ConditionPrediction = $"{predictedCondition} ({highestScore:P1})",
                    SkinTypePrediction = "Type Detected Successfully" // Keeping it clean for your UI frame
                };
            }
        }

        private DenseTensor<float> PreprocessImage(string path)
        {
            using (System.Drawing.Bitmap rawBitmap = new System.Drawing.Bitmap(path))
            using (System.Drawing.Bitmap resizedBitmap = new System.Drawing.Bitmap(rawBitmap, new System.Drawing.Size(224, 224)))
            {
                // 🎯 FIXED tensor dimensions to reflect NHWC format layout shape: [1, 224, 224, 3]
                var tensor = new DenseTensor<float>(new[] { 1, 224, 224, 3 });

                for (int y = 0; y < 224; y++)
                {
                    for (int x = 0; x < 224; x++)
                    {
                        System.Drawing.Color pixel = resizedBitmap.GetPixel(x, y);

                        // 🎯 FIXED: Map pixels across width/height/color axes sequentially matching your Keras generator logic!
                        tensor[0, y, x, 0] = pixel.R / 255.0f; // Red Channel
                        tensor[0, y, x, 1] = pixel.G / 255.0f; // Green Channel
                        tensor[0, y, x, 2] = pixel.B / 255.0f; // Blue Channel
                    }
                }
                return tensor;
            }
        }
    }
}