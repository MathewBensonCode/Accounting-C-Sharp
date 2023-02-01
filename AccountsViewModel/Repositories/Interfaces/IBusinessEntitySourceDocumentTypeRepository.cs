using System.Collections.Generic;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsModelCore.Classes;

namespace AccountsViewModel.Repositories.Interfaces
{
    public interface IBusinessEntitySourceDocumentTypeRepository :
        IRepository<BusinessEntitySourceDocumentType>
    {
        ICollection<BusinessEntitySourceDocumentType> GetBusinessEntitySourceDocumentTypesForBusinessEntity(IBusinessEntity businessEntity);
    }
}
