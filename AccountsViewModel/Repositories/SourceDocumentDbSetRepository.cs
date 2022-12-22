using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;
using AccountsEntityFrameworkCore;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Repositories
{
    public class SourceDocumentDbSetRepository
        : DbSetRepository<SourceDocument>, ISourceDocumentRepository
    {
        public SourceDocumentDbSetRepository(AccountsDbContext context)
        : base(context, 10)
        {
        }

        public ICollection<SourceDocument> GetSourceDocumentsForBusinessEntity(BusinessEntity businessEntity)
        {
            throw new System.NotImplementedException();
        }
    }

}
