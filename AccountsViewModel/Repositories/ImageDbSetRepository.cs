using Accounts.Repositories;
using AccountsEntityFrameworkCore;
using AccountLib.Interfaces.SourceDocuments;
using System.Collections.Generic;
using System.Linq;
using AccountsModelCore.Classes.DocumentImages;

namespace AccountsViewModel.Repositories
{
    public class ImageDbSetRepository
        : DbSetRepository<DocumentImage>, IImageRepository
    {
        public ImageDbSetRepository(AccountsDbContext context, int pageSize = 10)
        : base(context, pageSize)
        {
        }

        public ICollection<DocumentImage> GetImagesForSourceDocument(ISourceDocument sourceDocument)
        {
            return _dbSet.Where(sd => sd.SourceDocumentId == sourceDocument.Id).ToList();
        }
    }

}
