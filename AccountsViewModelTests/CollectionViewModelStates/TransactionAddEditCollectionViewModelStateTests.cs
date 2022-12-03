using System.ComponentModel;
using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using Moq;
using Prism.Commands;
using Xunit;

namespace AccountsViewModelTests.CollectionViewModelStates
{
    public abstract class TransactionAddEditCollectionViewModelTests
    {
        protected Mock<ICommandViewModelFactory<Transaction>> Commandfactory { get; set; }
        protected Mock<Transaction> Transaction { get; set; }
        protected Mock<IEntityViewModel<Transaction>> Transactionviewmodel { get; set; }
        protected Mock<IEntityViewModel<Account>> Debitaccountviewmodel { get; set; }
        protected Mock<IEntityViewModel<Account>> Creditaccountviewmodel { get; set; }
        protected Mock<IEntityCollectionViewModel<Account>> Debitaccountcollectionviewmodel { get; set; }
        protected Mock<ICollectionListViewModelState<Account>> Debitaccountlistcollectionviewmodelstate { get; set; }
        protected Mock<IEntityCollectionViewModel<Account>> Creditaccountcollectionviewmodel { get; set; }
        protected Mock<ICollectionListViewModelState<Account>> Creditaccountlistcollectionviewmodelstate { get; set; }
        protected Mock<IEntityCollectionViewModel<Transaction>> Transactioncollectionviewmodel { get; set; }
        protected Mock<ICommandViewModel> Commandviewmodel { get; set; }
        protected Mock<ITransactionAccountSelectionCollectionViewModelFactory> Transactionaccountcollectionviewmodelfactory { get; set; }
        protected DelegateCommand Command { get; set; }
        protected Mock<ICollectionListViewModelState<Transaction>> Listviewmodelstate { get; set; }
        protected Mock<IRepository<Transaction>> Repository { get; set; }
        protected abstract TransactionAddEditCollectionViewModelState Sut { get; set; }

        public TransactionAddEditCollectionViewModelTests()
        {
            Transactioncollectionviewmodel = new Mock<IEntityCollectionViewModel<Transaction>>();
            Commandfactory = new Mock<ICommandViewModelFactory<Transaction>>();
            Transactionaccountcollectionviewmodelfactory = new Mock<ITransactionAccountSelectionCollectionViewModelFactory>();
            Debitaccountcollectionviewmodel = new Mock<IEntityCollectionViewModel<Account>>();
            Debitaccountlistcollectionviewmodelstate = new Mock<ICollectionListViewModelState<Account>>();
            Creditaccountcollectionviewmodel = new Mock<IEntityCollectionViewModel<Account>>();
            Creditaccountlistcollectionviewmodelstate = new Mock<ICollectionListViewModelState<Account>>();
            Transaction = new Mock<Transaction>();
            Transactionviewmodel = new Mock<IEntityViewModel<Transaction>>();
            Debitaccountviewmodel = new Mock<IEntityViewModel<Account>>();
            Creditaccountviewmodel = new Mock<IEntityViewModel<Account>>();
            Commandviewmodel = new Mock<ICommandViewModel>();
            Command = new DelegateCommand(() => { });
            Listviewmodelstate = new Mock<ICollectionListViewModelState<Transaction>>();
            Repository = new Mock<IRepository<Transaction>>();

            _ = Commandviewmodel.Setup(a => a.Command)
                .Returns(Command);

            _ = Transactionviewmodel.Setup(a => a.Entity)
                .Returns(Transaction.Object);

            _ = Debitaccountcollectionviewmodel.Setup(a => a.CollectionViewState)
                .Returns(Debitaccountlistcollectionviewmodelstate.Object);

            _ = Creditaccountcollectionviewmodel.Setup(a => a.CollectionViewState)
                .Returns(Creditaccountlistcollectionviewmodelstate.Object);

            _ = Transactionaccountcollectionviewmodelfactory.Setup(a => a.GetDebitAccountCollectionViewModelForTransaction(Transaction.Object))
                .Returns(Debitaccountcollectionviewmodel.Object);

            _ = Transactionaccountcollectionviewmodelfactory.Setup(a => a.GetCreditAccountCollectionViewModelForTransaction(Transaction.Object))
                .Returns(Creditaccountcollectionviewmodel.Object);

            _ = Commandfactory.Setup(a => a.CreateSaveNewCommand(
                It.IsAny<ICollectionAddViewModelState<Transaction>>(),
                It.IsAny<ICollectionListViewModelState<Transaction>>(),
                It.IsAny<IRepository<Transaction>>(),
                It.IsAny<IEntityCollectionViewModel<Transaction>>()))
                .Returns(Commandviewmodel.Object);

            _ = Commandfactory.Setup(a => a.CreateSaveEditCommand(
                It.IsAny<ICollectionEditViewModelState<Transaction>>(),
                It.IsAny<ICollectionListViewModelState<Transaction>>(),
                It.IsAny<IRepository<Transaction>>(),
                It.IsAny<IEntityCollectionViewModel<Transaction>>()))
                .Returns(Commandviewmodel.Object);

            _ = Commandfactory.Setup(a => a.CreateCancelAddNewEditCommand(
                It.IsAny<ICollectionListViewModelState<Transaction>>(),
                It.IsAny<IEntityCollectionViewModel<Transaction>>()
                ))
                .Returns(Commandviewmodel.Object);

        }

        [Fact]
        public void ShouldImplementITransacactionCollectionAddEditViewModelState()
        {
            _ = Assert.IsAssignableFrom<ITransactionCollectionAddEditViewModelState>(Sut);
        }

        [Fact]
        public void ShouldGetDebitAccountCollectionViewModelForCurrentNewEntity()
        {
            Sut.EntityViewModel = Transactionviewmodel.Object;
            Assert.Same(Debitaccountcollectionviewmodel.Object, Sut.DebitAccountCollectionViewModel);
        }

        [Fact]
        public void ShouldGetCreditAccountCollectionViewModelForCurrentNewEntity()
        {
            Sut.EntityViewModel = Transactionviewmodel.Object;
            Assert.Same(Creditaccountcollectionviewmodel.Object, Sut.CreditAccountCollectionViewModel);
        }

        [Fact]
        public void ShouldChangeTheDebitAccountIdOnTheCurrentEntityWhenTheDebitAccountCollectionViewModelCurrentEntityChanges()
        {
            _ = Debitaccountviewmodel.Setup(a => a.Id)
                .Returns(3);
            _ = Transactionviewmodel.As<ITransactionViewModel>().SetupProperty(a => a.DebitAccountId);
            Sut.EntityViewModel = Transactionviewmodel.Object;
            SetupPropertyChangedOnDebitAccountCollectionListViewModelState();
            Assert.Equal(3, Transactionviewmodel.As<ITransactionViewModel>().Object.DebitAccountId);
        }

        [Fact]
        public void ShouldChangeTheCreditAccountIdOnTheCurrentEntityWhenTheCreditAccountCollectionViewModelCurrentEntityChanges()
        {
            _ = Creditaccountviewmodel.Setup(a => a.Id)
                .Returns(3);
            _ = Transactionviewmodel.As<ITransactionViewModel>().SetupProperty(a => a.CreditAccountId);
            Sut.EntityViewModel = Transactionviewmodel.Object;
            SetupPropertyChangedOnCreditAccountCollectionListViewModelState();
            Assert.Equal(3, Transactionviewmodel.As<ITransactionViewModel>().Object.CreditAccountId);
        }

        private void SetupPropertyChangedOnDebitAccountCollectionListViewModelState()
        {
            _ = Debitaccountlistcollectionviewmodelstate.SetupProperty(a => a.EntityViewModel);
            Debitaccountlistcollectionviewmodelstate.Object.EntityViewModel = Debitaccountviewmodel.Object;
            Debitaccountlistcollectionviewmodelstate.Raise(a => a.PropertyChanged += null, this, new PropertyChangedEventArgs("Entity"));
        }


        private void SetupPropertyChangedOnCreditAccountCollectionListViewModelState()
        {
            _ = Creditaccountlistcollectionviewmodelstate.SetupProperty(a => a.EntityViewModel);
            Creditaccountlistcollectionviewmodelstate.Object.EntityViewModel = Creditaccountviewmodel.Object;
            Creditaccountlistcollectionviewmodelstate.Raise(a => a.PropertyChanged += null, this, new PropertyChangedEventArgs("Entity"));
        }
    }
}
