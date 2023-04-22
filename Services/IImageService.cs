namespace CirzzarCurr.Services
{
    public interface IImageService
    {
        void Delete(string folder, string name);
        string? Encode(Image? image);
        string? GetEncodedByPath(string path);
        string GetPath(string folder, string name);
        void Save(string base64Image, string path);
        string Save(string base64Image, string folder, string name);
    }
}