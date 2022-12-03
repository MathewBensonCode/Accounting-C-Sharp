using AccountLib.Model.BusinessEntities;
using AccountsEntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccountsViewModel.Repositories
{
    public class RegisteredBusinessDbSetRepository :
        BusinessEntityDbSetRepository
    {
        public RegisteredBusinessDbSetRepository(AccountsDbContext context) : base(context)
        {
        }

        public override IEnumerable<BusinessEntity> GetPageCollection(int Id)
        {
            var pagesize = GetPageSize();
            return _dbSet
                .OfType<RegisteredBusiness>()
                .Include(a=>a.RegisteredOwners)
                .Skip((Id - 1) * pagesize)
                .Take(pagesize)
                .ToList() as IEnumerable<BusinessEntity>;
        }
    }
}
