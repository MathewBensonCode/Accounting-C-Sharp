using AccountLib.Interfaces.Transactions;
using AccountLib.Model.Transactions;
using AccountsViewModel.Entity.Interfaces;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.Transactions;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Moq;
using Xunit;

namespace AccountsViewModelTests.EntityViewModel.Tests.Transactions
{

    public class TransactionViewModelTests
   : EntityViewModelTests<Transaction>
    {
        private readonly TransactionViewModel TransactionSut;
        private readonly ITransaction transaction;
        protected Mock<IAccountViewModelFactory> AccountViewModelFactory { get; set; }
        protected Mock<ISourceDocumentViewModelFactory> SourceDocumentViewModelFactory { get; set; }
        protected override EntityViewModel<Transaction> Sut { get; set; }
        protected override Transaction Entity { get; set; }

        private readonly int TestId = 4;
        private readonly decimal TestAmount = 5.00m;
        private readonly Mock<ISourceDocumentViewModel> sourcedocumentviewmodel;
        private readonly Mock<IAccountViewModel> debitaccountviewmodel;
        private readonly Mock<IAccountViewModel> creditaccountviewmodel;

        public TransactionViewModelTests()
        {
            AccountViewModelFactory = new Mock<IAccountViewModelFactory>();
            SourceDocumentViewModelFactory = new Mock<ISourceDocumentViewModelFactory>();
            Entity = new Transaction();
            transaction = Entity;

            transaction.SourceDocumentId = TestId;
            transaction.Amount = TestAmount;

            sourcedocumentviewmodel = new();
            _ = SourceDocumentViewModelFactory.Setup(a => a.CreateSourceDocumentViewModelForTransaction(Entity)).Returns(sourcedocumentviewmodel.Object);

            debitaccountviewmodel = new();
            creditaccountviewmodel = new();

            AccountViewModelFactory.Setup(a => a.GetDebitAccountViewModelForTransaction(Entity)).Returns(debitaccountviewmodel.Object);
            AccountViewModelFactory.Setup(a => a.GetCreditAccountViewModelForTransaction(Entity)).Returns(creditaccountviewmodel.Object);

            TransactionSut = new TransactionViewModel(
                transaction,
                AccountViewModelFactory.Object,
                SourceDocumentViewModelFactory.Object,
                ErrorCollection.Object
                );

            Sut = TransactionSut;
        }

        [Fact]
        public void RaisesPropertyChangedNotificationWhenDebitAccountIdPropertyChanges()
        {
            Assert.PropertyChanged(TransactionSut, "DebitAccountId", () => { TransactionSut.DebitAccountId = TestId; });
        }

        [Fact]
        public void GetsUnderlyingAccountIdThroughDebitAccountIdProperty()
        {
            transaction.DebitAccountId = TestId;
            Assert.Equal(TestId, TransactionSut.DebitAccountId);
        }

        [Fact]
        public void SetsUnderlyingDebitAccountIdWhenDebitAccountIdPropertySet()
        {
            TransactionSut.DebitAccountId = TestId;
            Assert.Equal(TestId, transaction.DebitAccountId);
        }

        [Fact]
        public void RaisesPropertyChangedNotificationWhenCreditAccountIdPropertyChanges()
        {
            Assert.PropertyChanged(TransactionSut, "CreditAccountId", () => { TransactionSut.CreditAccountId = TestId; });
        }

        [Fact]
        public void GetsUnderlyingCreditAccountIdThroughCreditAccountIdProperty()
        {
            transaction.CreditAccountId = TestId;
            Assert.Equal(TestId, TransactionSut.CreditAccountId);
        }

        [Fact]
        public void SetsUnderlyingCreditAccountIdWhenCreditAccountIdPropertySet()
        {
            TransactionSut.CreditAccountId = TestId;
            Assert.Equal(TestId, transaction.CreditAccountId);
        }

        [Fact]
        public void RaisesPropertyChangedNotificationWhenSourceDocumentIdPropertyChanges()
        {
            Assert.PropertyChanged(TransactionSut, "SourceDocumentId", () => { TransactionSut.SourceDocumentId = TestId; });
        }

        [Fact]
        public void GetsUnderlyingSourceDocumentIdThroughSourceDocumentIdProperty()
        {
            Assert.Equal(TestId, TransactionSut.SourceDocumentId);
        }

        [Fact]
        public void SetsUnderlyingSourceDocumentIdWhenSourceDocumentIdPropertySet()
        {
            var newid = TestId + 4;
            TransactionSut.SourceDocumentId = newid;
            Assert.Equal(newid, transaction.SourceDocumentId);
        }

        [Fact]
        public void RaisesPropertyChangedNotificationWhenAmountPropertyChanges()
        {
            Assert.PropertyChanged(TransactionSut, "Amount", () => { TransactionSut.Amount = TestAmount; });
        }

        [Fact]
        public void GetsUnderlyingAmountThroughAmountProperty()
        {
            Assert.Equal(TestAmount, TransactionSut.Amount);
        }

        [Fact]
        public void SetsUnderlyingTransactionAmountWhenTransactionPropertySet()
        {
            var newtestamount = TestAmount + 5;
            TransactionSut.Amount = newtestamount;
            Assert.Equal(newtestamount, transaction.Amount);
        }

        [Fact]
        public void SourceDocumentViewModelPropertyShouldNotBeNull()
        {
            Assert.NotNull(TransactionSut.SourceDocumentViewModel);
        }

        [Fact]
        public void DebitAccountViewModelPropertyShouldNotBeNull()
        {
            Assert.NotNull(TransactionSut.DebitAccountViewModel);
        }

        [Fact]
        public void CreditAccountViewModelPropertyShouldNotBeNull()
        {
            Assert.NotNull(TransactionSut.CreditAccountViewModel);
        }

    }
}
