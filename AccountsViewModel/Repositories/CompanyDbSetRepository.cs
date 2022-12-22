using System.Collections.Generic;
using System.Linq;
using AccountLib.Model.BusinessEntities;
using AccountsEntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountsViewModel.Repositories
{
    public class CompanyDbSetRepository :
        BusinessEntityDbSetRepository
    {
        public CompanyDbSetRepository(AccountsDbContext context) :
            base(context)
        {
        }

        public override IEnumerable<BusinessEntity> GetPageCollection(int Id)
        {
            var pagesize = GetPageSize();
            return _dbSet
                .OfType<Company>()
                .Include(a => a.ShareHolders)
                .Include(a => a.Directors)
                .Skip((Id - 1) * pagesize)
                .Take(pagesize)
                .ToList();
        }
    }
}
