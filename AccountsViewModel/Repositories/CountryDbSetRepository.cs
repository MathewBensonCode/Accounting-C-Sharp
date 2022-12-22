using AccountsEntityFrameworkCore;
using AccountsModelCore.Classes;

namespace AccountsViewModel.Repositories
{
    public class CountryDbSetRepository
        : DbSetRepository<Country>
    {
        public CountryDbSetRepository(AccountsDbContext context)
        : base(context, 10)
        {
        }
    }

}
