using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModelTests.AutofixtureAttributes;
using Xunit;

namespace AccountsViewModelTests.Repositories.Tests.MainRepositories
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
