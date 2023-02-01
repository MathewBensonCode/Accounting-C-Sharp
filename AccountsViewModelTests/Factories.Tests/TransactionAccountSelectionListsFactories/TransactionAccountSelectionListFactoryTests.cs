using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.Factories.Interfaces.TransactionAccountSelectionLists;
using AccountsViewModel.Factories.TransactionAccountSelectionListFactories;
using AccountsViewModelTests.AutofixtureAttributes;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.TransactionAccountSelectionListsFactories
{
    public abstract class TransactionAccountSelectionListFactoryTests<T> where T : Transaction
    {
        [Theory, AutoCatalogData]
        public void ShouldImplementITransactionAccountSelection(
            TransactionAccountSelectionListFactory<T> sut
            )
        {
            Assert.IsAssignableFrom<ITransactionAccountSelectionListFactory<T>>(sut);
        }

        [Theory, AutoCatalogData]
        public void ShouldReturnCollectionOfAccountsForDebitSelection(
            TransactionAccountSelectionListFactory<T> sut
            )
        {
            Assert.IsAssignableFrom<ICollection<Account>>(sut.DebitAccountSelectionList);
        }

        [Theory, AutoCatalogData]
        public void ShouldReturnCollectionofAccountsForCreditSelection(
            TransactionAccountSelectionListFactory<T> sut
            )
        {
            Assert.IsAssignableFrom<ICollection<Account>>(sut.CreditAccountSelectionList);
        }

    }
}
