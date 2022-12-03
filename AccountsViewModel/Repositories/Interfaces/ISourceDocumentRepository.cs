using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;

namespace Accounts.Repositories
{
    public interface ISourceDocumentRepository : IRepository<SourceDocument>
    {
        ICollection<SourceDocument> GetSourceDocumentsForBusinessEntity(BusinessEntity businessEntity);
    }

}
