using CirzzarCurr.Models.Enums;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using System.IO;

namespace CirzzarCurr.Services
{
    public class ImageService : IImageService
    {
        private readonly string _basePath;

        public ImageService(IConfiguration configuration, IHostEnvironment environment)
        {
            var imageSection = configuration.GetSection("AppSettings:ImagePath");

            if (!imageSection.Exists())
            {
                throw new InvalidOperationException("AppSettings:ImagePath не найден в конфигурации.");
            }

            string relativePath = imageSection.Value;
            _basePath = Path.Combine(environment.ContentRootPath, relativePath);
        }

        public Image? DecodeImage(string? encoded)
        {
            if (string.IsNullOrEmpty(encoded))
            {
                return null;
            }

            byte[] imageData = Convert.FromBase64String(encoded);
            using MemoryStream memoryStream = new(imageData);
            return Image.Load(memoryStream);
        }

        public string? EncodeImage(Image? image)
        {
            if (image == null)
            {
                return null;
            }

            using MemoryStream memoryStream = new();
            image.Save(memoryStream, new PngEncoder());
            byte[] imageData = memoryStream.ToArray();
            return Convert.ToBase64String(imageData);
        }

        public Image GetImageByPath(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found", path);
            }
            return Image.Load(path);
        }

        public string GetImagePath(Image image, string folder, string name)
        {
            string imagePath = Path.Combine(_basePath, folder, name + ".png");
            if (!File.Exists(imagePath))
            {
                SaveImage(image, imagePath);
            }
            return imagePath;
        }

        public void SaveImage(Image image, string path) => image.Save(path);
    }
}
