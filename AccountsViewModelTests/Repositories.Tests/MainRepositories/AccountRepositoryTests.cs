using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using Xunit;

namespace AccountsViewModelTests.RepositoryTests
{
    public class AccountsRepositoryTests
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementIRepository(
            IRepository<Account> sut
                )
        {
            Assert.IsAssignableFrom<IRepository<Account>>(sut);
        }
    }
}
