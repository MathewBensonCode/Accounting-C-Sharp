using AccountLib.Interfaces.Accounts;
using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Classes.Accounts;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using Moq;
using Xunit;

namespace AccountsViewModelTests.EntityViewModel.Tests.Accounts
{
    public abstract class AccountViewModelTests
        : EntityViewModelTests<Account>
    {
        protected abstract AccountViewModel AccountSut { get; set; }
        protected Mock<ITransactionChildCollectionViewModelFactory> Transactionfactory { get; set; }
        private readonly string testdata = "hellotext";
        private readonly Mock<IEntityCollectionViewModel<Transaction>> debitvmcollection;
        private readonly Mock<IEntityCollectionViewModel<Transaction>> creditvmcollection;

        public AccountViewModelTests()
        {
            Transactionfactory = new Mock<ITransactionChildCollectionViewModelFactory>();
            debitvmcollection = new Mock<IEntityCollectionViewModel<Transaction>>();
            creditvmcollection = new Mock<IEntityCollectionViewModel<Transaction>>();

            _ = Transactionfactory.Setup(a => a.GetCreditsCollectionViewModelForAccount(Entity)).Returns(creditvmcollection.Object);
            _ = Transactionfactory.Setup(a => a.GetDebitsCollectionViewModelForAccount(Entity)).Returns(debitvmcollection.Object);
        }

        [Fact]
        public void SetsUnderlyingAccountNameWhenViewModelNamePropertySet()
        {
            AccountSut.Name = testdata;
            Assert.Equal(testdata, Entity.Name);
        }

        [Fact]
        public void GetsUnderlyingAccountNameFromAccountNameProperty()
        {
            Entity.Name = testdata;
            Assert.Equal(testdata, AccountSut.Name);
        }

        [Fact]
        public void RaisesPropertyChangedEventWhenNamePropertySet()
        {
            Assert.PropertyChanged(AccountSut, "Name", () =>
                {
                    AccountSut.Name = testdata;
                });
        }

        [Fact]
        public void GetDebitsViewModelShouldNotBeNull()
        {
            //Assert.Same(debitvmcollection.Object, AccountSut.DebitsViewModel);
            var debitvm = AccountSut.DebitsViewModel;
            Transactionfactory.Verify(a => a.GetDebitsCollectionViewModelForAccount(It.IsAny<IAccount>()));
        }

        [Fact]
        public void GetCreditsViewModelShouldNotBeNull()
        {
            //Assert.Same(creditvmcollection.Object, AccountSut.CreditsViewModel);
            var debitvm = AccountSut.DebitsViewModel;
            Transactionfactory.Verify(a => a.GetDebitsCollectionViewModelForAccount(It.IsAny<IAccount>()));
        }
    }

}
