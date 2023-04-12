using CirzzarCurr.Models.Enums;

namespace CirzzarCurr.Services
{


    public interface IImageService
    {
        Image DecodeImage(string encodedImage);
        string EncodeImage(Image image);
        Image GetImageByPath(string path);
        string GetImagePath(Image image, string folder, string name);
        void SaveImage(Image image, string path);
    }


}
