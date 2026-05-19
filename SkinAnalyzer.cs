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

        // MUST MATCH TRAINING ORDER EXACTLY
        private readonly string[] _labels =
        {
            "Acne and Rosacea Photos",
            "Eczema Photos",
            "Light Diseases and Disorders of Pigmentation",
            "Seborrheic Keratoses and other Benign Tumors"
        };

        public SkinAnalyzer()
        {
            string modelPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets",
                "PreciseSkin_Model.onnx"
            );

            if (!File.Exists(modelPath))
                throw new Exception("ONNX model not found: " + modelPath);

            _session = new InferenceSession(modelPath);
        }

        public SkinAnalysisResult AnalyzeImage(string imagePath)
        {
            using var bitmap = new Bitmap(imagePath);
            using var resized = new Bitmap(bitmap, new Size(224, 224));

            var input = new DenseTensor<float>(new[] { 1, 224, 224, 3 });

            for (int y = 0; y < 224; y++)
            {
                for (int x = 0; x < 224; x++)
                {
                    Color pixel = resized.GetPixel(x, y);

                    input[0, y, x, 0] = (pixel.R / 127.5f) - 1f;
                    input[0, y, x, 1] = (pixel.G / 127.5f) - 1f;
                    input[0, y, x, 2] = (pixel.B / 127.5f) - 1f;
                }
            }

            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("input_image", input)
            };

            using var results = _session.Run(inputs);

            // FIX 1: safer output handling (prevents crash if name differs)
            var output = results.FirstOrDefault();

            if (output == null)
                throw new Exception("ONNX model returned no outputs.");

            float[] scores = output.AsEnumerable<float>().ToArray();

            // FIX 2: safety check (prevents index crash)
            if (scores.Length != _labels.Length)
                throw new Exception($"Mismatch: model outputs {scores.Length} classes but labels has {_labels.Length}");

            int maxIndex = Array.IndexOf(scores, scores.Max());
            string prediction = _labels[maxIndex];

            string debug =
                $"Acne: {scores[0]:F3}\n" +
                $"Eczema: {scores[1]:F3}\n" +
                $"Pigmentation: {scores[2]:F3}\n" +
                $"Seborrheic: {scores[3]:F3}";

            return new SkinAnalysisResult
            {
                ConditionPrediction = prediction,
                RawScores = debug
            };
        }
    }
}