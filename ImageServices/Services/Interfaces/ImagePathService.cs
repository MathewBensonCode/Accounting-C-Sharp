namespace AccountsViewModelsCore.Services.Interfaces
{
    public interface IImagePathService
    {
        string GetFolderPathForNewImage();
	string GetFileNameForNewImage();
	string GetFullPath(string foldername, string filename);
    }
}
