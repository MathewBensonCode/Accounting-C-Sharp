using Accounts.Repositories;
using AccountLib.Model.Source_Documents;
using System.Collections.Generic;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsRepositoriesCore.Interfaces
{
    public interface IBusinessEntitySourceDocumentTypeRepository:
        IRepository<BusinessEntitySourceDocumentType>
    {
        ICollection<BusinessEntitySourceDocumentType> GetBusinessEntitySourceDocumentTypesForBusinessEntity(IBusinessEntity businessEntity); 
    }
}
