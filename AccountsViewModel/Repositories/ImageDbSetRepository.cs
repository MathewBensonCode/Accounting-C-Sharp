using System.Collections.Generic;
using System.Linq;
using AccountsEntityFrameworkCore;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Interfaces.SourceDocuments;
using AccountsViewModel.Repositories.Interfaces;

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
