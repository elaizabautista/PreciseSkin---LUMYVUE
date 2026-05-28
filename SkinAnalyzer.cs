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
        public string RawScores { get; set; }
    }

    public class SkinAnalyzer
    {
        private readonly InferenceSession _session;

 
        private readonly string[] _labels =
        {
            "Acne",
            "Eczema",
            "Hyperpigmentation",
            "Normal"
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

            _session = new InferenceSession(modelPath);
        }

        public SkinAnalysisResult AnalyzeImage(string imagePath)
        {
            using var bitmap = new Bitmap(imagePath);
            using var resized = new Bitmap(bitmap, new Size(224, 224));

            // NHWC format
            var tensor = new DenseTensor<float>(new[] { 1, 224, 224, 3 });

            for (int y = 0; y < 224; y++)
            {
                for (int x = 0; x < 224; x++)
                {
                    Color pixel = resized.GetPixel(x, y);

                    // MobileNetV2 normalization
                    tensor[0, y, x, 0] = (pixel.R / 127.5f) - 1f;
                    tensor[0, y, x, 1] = (pixel.G / 127.5f) - 1f;
                    tensor[0, y, x, 2] = (pixel.B / 127.5f) - 1f;
                }
            }

            // INPUT NAME
            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("input_image", tensor)
            };

            using var results = _session.Run(inputs);

            // OUTPUT NAME
            var output = results.First(x => x.Name == "skin_condition_output");

            float[] scores = output.AsEnumerable<float>().ToArray();

            int maxIndex = Array.IndexOf(scores, scores.Max());

            string prediction = _labels[maxIndex];

            string debug =
                $"Acne: {scores[0]:P2}\n" +
                $"Eczema: {scores[1]:P2}\n" +
                $"Hyperpigmentation: {scores[2]:P2}\n" +
                $"Normal: {scores[3]:P2}";

            return new SkinAnalysisResult
            {
                ConditionPrediction =
                    $"{prediction} ({scores[maxIndex]:P2})",

                RawScores = debug
            };
        }
    }
}