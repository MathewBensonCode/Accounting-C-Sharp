using AccountLib.Model.BusinessEntities;
using Accounts.Repositories;
using AccountsEntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccountsViewModel.Repositories
{
    public class BusinessEntityDbSetRepository
        : DbSetRepository<BusinessEntity>, IBusinessEntityRepository
    {
        public BusinessEntityDbSetRepository(AccountsDbContext context)
        : base(context)
        {
        }


        public AccountsDbContext AccountsDbContext
        {
            get
            {
                return _context as AccountsDbContext;
            }
        }

        public override BusinessEntity Find(int Id)
        {
            return AccountsDbContext.BusinessEntities.First(b => b.Id == Id);
        }

        public IEnumerable<BusinessEntity> GetCompanyBusinessEntityAccounts()
        {
            return AccountsDbContext.BusinessEntities.OfType<Company>().ToList();
        }

        public IEnumerable<BusinessEntity> GetPersonBusinessEntityAccounts()
        {
            return AccountsDbContext.BusinessEntities.OfType<Person>().ToList();
        }

        public IEnumerable<BusinessEntity> GetRegisteredBusinessEntityAccounts()
        {
            return AccountsDbContext.BusinessEntities.OfType<RegisteredBusiness>().ToList();
        }
    }


}
