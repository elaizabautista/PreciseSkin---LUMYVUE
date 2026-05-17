using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

// 🌟 Keep these exact three ImageSharp namespaces at the top!
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

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

        // Ensure these labels match the exact order of your Python training classes!
        private readonly string[] _diseaseLabels = {
            "Melanoma", "Melanocytic Nevus", "Basal Cell Carcinoma",
            "Actinic Keratosis", "Benign Keratosis", "Dermatofibroma", "Vascular Lesion"
        };

        private readonly string[] _skinTypeLabels = {
            "Type I", "Type II", "Type III", "Type IV", "Type V", "Type VI"
        };

        public SkinAnalyzer()
        {
            string modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "PreciseSkin_Model.onnx");
            _onnxSession = new InferenceSession(modelPath);
        }

        public SkinAnalysisResult AnalyzeImage(string imagePath)
        {
            // 1. Preprocess the image to a standardized 1x3x224x224 input tensor
            DenseTensor<float> inputTensor = PreprocessImage(imagePath);

            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("input", inputTensor)
            };

            // 2. Run inference using our ONNX session
            using IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = _onnxSession.Run(inputs);
            var outputsList = results.ToList();

            // ⚠️ Replace these with your exact ONNX model output layer node names if they differ
            float[] diseaseRawScores = outputsList.First(o => o.Name == "disease_output").AsEnumerable<float>().ToArray();
            float[] skinTypeRawScores = outputsList.First(o => o.Name == "fitzpatrick_output").AsEnumerable<float>().ToArray();

            // 4. Decode output arrays to text predictions via ArgMax (highest index score)
            int highestDiseaseIndex = diseaseRawScores.ToList().IndexOf(diseaseRawScores.Max());
            string predictedDisease = _diseaseLabels[highestDiseaseIndex];

            int highestSkinTypeIndex = skinTypeRawScores.ToList().IndexOf(skinTypeRawScores.Max());
            string predictedSkinType = _skinTypeLabels[highestSkinTypeIndex];

            return new SkinAnalysisResult
            {
                ConditionPrediction = predictedDisease,
                SkinTypePrediction = predictedSkinType
            };
        }

        private DenseTensor<float> PreprocessImage(string path)
        {
            // 🌟 FIXED: Explicitly calling SixLabors.ImageSharp.Image on both parts of this using statement 
            // to completely bypass the Windows Forms conflicting engine.
            using (SixLabors.ImageSharp.Image<Rgb24> image = SixLabors.ImageSharp.Image.Load<Rgb24>(path))
            {
                image.Mutate(x => x.Resize(224, 224));

                var tensor = new DenseTensor<float>(new[] { 1, 3, 224, 224 });

                for (int y = 0; y < 224; y++)
                {
                    for (int x = 0; x < 224; x++)
                    {
                        Rgb24 pixel = image[x, y];

                        // Scale color bytes down to float coordinates (0.0 to 1.0 standard normalization)
                        tensor[0, 0, y, x] = pixel.R / 255.0f; // Red
                        tensor[0, 1, y, x] = pixel.G / 255.0f; // Green
                        tensor[0, 2, y, x] = pixel.B / 255.0f; // Blue
                    }
                }
                return tensor;
            }
        }
    }
}