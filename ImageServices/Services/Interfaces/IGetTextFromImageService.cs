namespace ImageServices.Services.Interfaces
{
    public interface IGetTextFromImageServices
    {
        string GetTextFromImageUsingTesseract(string path);
    }
}
