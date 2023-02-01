using System.Collections.Generic;
using System.Linq;
using AccountsEntityFrameworkCore;
using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.Repositories
{
    public class BusinessEntitySourceDocumentTypeDbSetRepository :
        DbSetRepository<BusinessEntitySourceDocumentType>, IBusinessEntitySourceDocumentTypeRepository
    {
        public BusinessEntitySourceDocumentTypeDbSetRepository(AccountsDbContext context) :
            base(context)
        {
        }

        public ICollection<BusinessEntitySourceDocumentType> GetBusinessEntitySourceDocumentTypesForBusinessEntity(IBusinessEntity businessEntity)
        {
            return AccountsDbContext.BusinessEntitySourceDocumentTypes
                .Where(a => a.BusinessEntityId == businessEntity.Id).ToList();
        }

        protected AccountsDbContext AccountsDbContext => _context;
    }
}
