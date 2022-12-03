using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;
using Accounts.Repositories;
using AccountsEntityFrameworkCore;

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
