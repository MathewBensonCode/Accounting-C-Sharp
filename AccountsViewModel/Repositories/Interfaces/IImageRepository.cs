using AccountLib.Interfaces.SourceDocuments;
using System.Collections.Generic;
using AccountsModelCore.Classes.DocumentImages;

namespace Accounts.Repositories
{
    public interface IImageRepository : IRepository<DocumentImage>
    {
        ICollection<DocumentImage> GetImagesForSourceDocument(ISourceDocument sourceDocument);
    }
}
