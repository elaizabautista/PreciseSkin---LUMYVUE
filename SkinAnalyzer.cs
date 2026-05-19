using System;
using System.Collections.Generic;
using System.Drawing;
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

        // MUST MATCH KAGGLE CLASS INDEXES
        private readonly string[] _diseaseLabels =
        {
            "Acne and Rosacea",
            "Eczema",
            "Hyperpigmentation"
        };

        public SkinAnalyzer()
        {
            string modelPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets",
                "PreciseSkin_Model.onnx"
            );

            if (!File.Exists(modelPath))
            {
                throw new Exception("ONNX model not found:\n" + modelPath);
            }

            _onnxSession = new InferenceSession(modelPath);
        }

        public SkinAnalysisResult AnalyzeImage(string imagePath)
        {
            DenseTensor<float> inputTensor = PreprocessImage(imagePath);

            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("input_image", inputTensor)
            };

            using var results = _onnxSession.Run(inputs);

            var output = results.First(x => x.Name == "skin_condition_output");

            float[] scores = output.AsEnumerable<float>().ToArray();

            // DEBUG OUTPUT
            string debug =
                $"Acne: {scores[0]:F4}\n" +
                $"Eczema: {scores[1]:F4}\n" +
                $"Hyperpigmentation: {scores[2]:F4}";

            int highestIndex = Array.IndexOf(scores, scores.Max());

            string prediction = _diseaseLabels[highestIndex];
            float confidence = scores[highestIndex];

            return new SkinAnalysisResult
            {
                ConditionPrediction =
                    $"{prediction} ({confidence:P1})",

                SkinTypePrediction = debug
            };
        }

        private DenseTensor<float> PreprocessImage(string imagePath)
        {
            using Bitmap bitmap = new Bitmap(imagePath);
            using Bitmap resized = new Bitmap(bitmap, new Size(224, 224));

            // NHWC FORMAT
            var tensor = new DenseTensor<float>(new[] { 1, 224, 224, 3 });

            for (int y = 0; y < 224; y++)
            {
                for (int x = 0; x < 224; x++)
                {
                    Color pixel = resized.GetPixel(x, y);

                    // MOBILE NET V2 NORMALIZATION
                    tensor[0, y, x, 0] = (pixel.R / 127.5f) - 1f;
                    tensor[0, y, x, 1] = (pixel.G / 127.5f) - 1f;
                    tensor[0, y, x, 2] = (pixel.B / 127.5f) - 1f;
                }
            }

            return tensor;
        }
    }
}