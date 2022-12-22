using System.Collections.Generic;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Interfaces.SourceDocuments;

namespace AccountsViewModel.Repositories.Interfaces
{
    public interface IImageRepository : IRepository<DocumentImage>
    {
        ICollection<DocumentImage> GetImagesForSourceDocument(ISourceDocument sourceDocument);
    }
}
