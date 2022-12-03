using AccountsEntityFrameworkCore;
using AccountLib.Model.Source_Documents;
using AccountsRepositoriesCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AccountsModelCore.Interfaces.BusinessEntities;

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

        protected AccountsDbContext AccountsDbContext
        {
            get
            {
                return _context as AccountsDbContext;
            }
        }
    }
}
