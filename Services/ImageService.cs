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
            using Image image = Image.Load(path);
            return Encode(image);
        }

        public string GetPath(string folder, string name)
        {
            return Path.Combine(_basePath, folder, name + ".png");
        }

        public void Save(string base64Image, string path)
        {
            byte[] imageBytes = Convert.FromBase64String(FixBase64ForImage(base64Image));
            File.WriteAllBytes(path, imageBytes);
        }

        public string Save(string base64Image, string folder, string name)
        {

            string fileExtension = GetFileExtensionFromBase64(base64Image);
            string path = Path.Combine(_basePath, folder, $"{name}.{fileExtension}");
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            Save(base64Image, path);
            return path;
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
            if (File.Exists(path))
                File.Delete(path);
        }

        private string GetFileExtensionFromBase64(string base64Image)
        {
            var data = base64Image[..100];
            if (data.Contains("data:image/jpeg;base64,"))
            {
                return "jpg";
            }
            else if (data.Contains("data:image/png;base64,"))
            {
                return "png";
            }
            else
            {
                throw new ArgumentException("Invalid image format");
            }
        }

        private string FixBase64ForImage(string image)
        {
            var sb = new System.Text.StringBuilder(image);
            sb.Replace("\r", "").Replace("\n", "").Replace(" ", "");

            if (sb[0] != '/')
            {
                int idx = sb.ToString().IndexOf("base64,");
                if (idx > 0)
                {
                    sb.Remove(0, idx + 7);
                }
            }
            return sb.ToString();
        }
    }
}
