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

        // 🎯 Your three target conditions matching your custom model keys
        // 🔄 Try rearranging the order to see if they snap into place:
        private readonly string[] _diseaseLabels = {
        "Eczema",             // Try making Eczema Index 0
        "Acne",               // Try making Acne Index 1
        "Hyperpigmentation"   // Index 2
        };

        public SkinAnalysisResult AnalyzeImage(string imagePath)
        {
            DenseTensor<float> inputTensor = PreprocessImage(imagePath);

            var inputs = new List<NamedOnnxValue>
    {
        NamedOnnxValue.CreateFromTensor("input", inputTensor)
    };

            using IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = _onnxSession.Run(inputs);
            var outputsList = results.ToList();

            // Extract the raw floats from the first output node
            float[] conditionScores = outputsList[0].AsEnumerable<float>().ToArray();

            string dynamicDiagnosticInfo = "";
            string predictedCondition = "Unknown";

            try
            {
                // 🛠️ Let's build a text summary of exactly how many items are in this array
                dynamicDiagnosticInfo = $"Array Length: {conditionScores.Length} | Values: ";
                for (int i = 0; i < conditionScores.Length; i++)
                {
                    dynamicDiagnosticInfo += $"[{i}]: {conditionScores[i]:F4} ";
                }

                // Standard classification logic assuming array elements are probabilities
                int highestConditionIndex = conditionScores.ToList().IndexOf(conditionScores.Max());

                if (highestConditionIndex >= 0 && highestConditionIndex < _diseaseLabels.Length)
                {
                    predictedCondition = _diseaseLabels[highestConditionIndex];
                }
                else
                {
                    predictedCondition = $"Index {highestConditionIndex} out of text label range";
                }
            }
            catch (Exception ex)
            {
                // If anything weird happens, catch it safely so the screen still loads
                dynamicDiagnosticInfo = $"Diagnostic parsing failed: {ex.Message}";
                predictedCondition = "Error parsing array";
            }

            return new SkinAnalysisResult
            {
                ConditionPrediction = predictedCondition,
                SkinTypePrediction = dynamicDiagnosticInfo // This will display the array info safely right on your UI
            };
        }

        private DenseTensor<float> PreprocessImage(string path)
        {
            using (System.Drawing.Bitmap rawBitmap = new System.Drawing.Bitmap(path))
            using (System.Drawing.Bitmap resizedBitmap = new System.Drawing.Bitmap(rawBitmap, new System.Drawing.Size(224, 224)))
            {
                var tensor = new DenseTensor<float>(new[] { 1, 224, 224, 3 });

                for (int y = 0; y < 224; y++)
                {
                    for (int x = 0; x < 224; x++)
                    {
                        System.Drawing.Color pixel = resizedBitmap.GetPixel(x, y);

                        tensor[0, y, x, 0] = pixel.R / 255.0f;
                        tensor[0, y, x, 1] = pixel.G / 255.0f;
                        tensor[0, y, x, 2] = pixel.B / 255.0f;
                    }
                }
                return tensor;
            }
        }
    }
}