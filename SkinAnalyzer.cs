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

        // 🎯 Your three exact target skin conditions
        // 🔄 Note: If Acne images predict Eczema or vice versa, simply change the order inside this list!
        private readonly string[] _diseaseLabels = {
            "Acne",
            "Eczema",
            "Hyperpigmentation"
        };

        public SkinAnalyzer()
        {
            // 🎯 FIXED: Bulletproof asset path routing
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string modelPath = Path.Combine(baseDir, "Assets", "PreciseSkin_Model.onnx");

            // Backup check: If it's not in the running bin folder, look in the project directory
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
                // Clear warning instead of a silent crash
                System.Windows.Forms.MessageBox.Show(
                    $"Critical Error: Could not find 'PreciseSkin_Model.onnx' file!\nChecked location: {modelPath}",
                    "Missing Model File"
                );
            }
        }

        public SkinAnalysisResult AnalyzeImage(string imagePath)
        {
            if (_onnxSession == null)
            {
                return new SkinAnalysisResult { ConditionPrediction = "Engine Error" };
            }

            DenseTensor<float> inputTensor = PreprocessImage(imagePath);

            var inputs = new List<NamedOnnxValue>
    {
        NamedOnnxValue.CreateFromTensor("input", inputTensor)
    };

            using IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = _onnxSession.Run(inputs);
            var outputsList = results.ToList();

            // 🎯 DIAGNOSTIC: Build a comprehensive map of ALL output names and sizes available
            string outputMapSummary = $"Total Output Nodes Found: {outputsList.Count} -> ";

            for (int i = 0; i < outputsList.Count; i++)
            {
                try
                {
                    float[] genericArray = outputsList[i].AsEnumerable<float>().ToArray();
                    outputMapSummary += $"[Node {i} Name: '{outputsList[i].Name}' (Length: {genericArray.Length})] ";
                }
                catch
                {
                    outputMapSummary += $"[Node {i} Name: '{outputsList[i].Name}' (Non-float layer)] ";
                }
            }

            // Default processing for safety
            float[] conditionScores = outputsList[0].AsEnumerable<float>().ToArray();
            string predictedCondition = "Scanning Model Nodes...";

            return new SkinAnalysisResult
            {
                ConditionPrediction = predictedCondition,
                SkinTypePrediction = outputMapSummary // Overrides text field to display the complete node names map!
            };
        }

        private DenseTensor<float> PreprocessImage(string path)
        {
            using (System.Drawing.Bitmap rawBitmap = new System.Drawing.Bitmap(path))
            using (System.Drawing.Bitmap resizedBitmap = new System.Drawing.Bitmap(rawBitmap, new System.Drawing.Size(224, 224)))
            {
                // Keep the dimensions that stop the input dimension crash
                var tensor = new DenseTensor<float>(new[] { 1, 224, 224, 3 });

                for (int y = 0; y < 224; y++)
                {
                    for (int x = 0; x < 224; x++)
                    {
                        System.Drawing.Color pixel = resizedBitmap.GetPixel(x, y);

                        // 🎯 ALTERNATIVE LAYOUT MAPPING:
                        // If your model has an internal transpose layer, it might be expecting 
                        // the channel index to map differently across the coordinates.
                        tensor[0, 0, y, x] = pixel.R / 255.0f;
                        tensor[0, 1, y, x] = pixel.G / 255.0f;
                        tensor[0, 2, y, x] = pixel.B / 255.0f;
                    }
                }
                return tensor;
            }
        }
    }
}