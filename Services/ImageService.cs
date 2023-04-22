using SixLabors.ImageSharp.Formats.Png;

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

        public string? GetEncodedByPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found", path);
            }
            Image image = Image.Load(path);
            return Encode(image);
        }

        public string GetPath(string folder, string name)
        {
            return Path.Combine(_basePath, folder, name + ".png");
        }

        public void Save(string base64Image, string path)
        {
            Image image = Decode(base64Image);
            Save(image, path);
        }

        public void Save(Image image, string path)
        {
            image.Save(path);
        }
        public string Save(string base64Image, string folder, string name)
        {
            string path = GetPath(folder, name);
            Save(base64Image, path);
            return path;
        }

        public Image? Decode(string? encoded)
        {
            if (string.IsNullOrEmpty(encoded))
            {
                return null;
            }

            byte[] imageData = Convert.FromBase64String(encoded);
            using MemoryStream memoryStream = new(imageData);
            return Image.Load(memoryStream);
        }

        public string? Encode(Image? image)
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

        public void Delete(string folder, string name)
        {
            string path = GetPath(folder, name);
            File.Delete(path);
        }
    }
}
