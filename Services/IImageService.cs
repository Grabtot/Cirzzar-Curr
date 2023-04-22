namespace CirzzarCurr.Services
{


    public interface IImageService
    {
        Image? Decode(string? encodedImage);
        string? Encode(Image? image);
        string? GetEncodedByPath(string path);
        string GetPath(string folder, string name);
        void Save(Image image, string path);
        string Save(string base64Image, string folder, string name);
        void Save(string base64Image, string path);
        void Delete(string folder, string name);
    }


}
