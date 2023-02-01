using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Unity.ViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityViewModelTests
{
    public class AccountsUnityViewModelFactoryTests :
        UnityViewModelFactoryTests<Account>
    {
        protected Mock<ITransaction> Transaction { get; set; }
        protected Mock<IAssetPurchaseTransaction> Assetpurchasetransaction { get; set; }
        protected Mock<IAssetSaleTransaction> Assetsaletransaction { get; set; }
        protected Mock<ICapitalAdditionTransaction> Capitaladditiontransaction { get; set; }
        protected Mock<ICapitalDrawingTransaction> Capitaldrawingtransaction { get; set; }
        protected Mock<IExpenseTransaction> Expensetransaction { get; set; }
        protected Mock<IIncomeTransaction> Incometransaction { get; set; }
        protected Mock<ILiabilityDecreaseTransaction> Liabilitydecreasetransaction { get; set; }
        protected Mock<ILiabilityIncreaseTransaction> Liabilityincreasetransaction { get; set; }

        protected override UnityViewModelFactory<Account> Sut { get; set; }

        private readonly AccountUnityViewModelFactory sut;

        public AccountsUnityViewModelFactoryTests()
        {
            Transaction = new Mock<ITransaction>();
            Assetpurchasetransaction = new Mock<IAssetPurchaseTransaction>();
            Assetsaletransaction = new Mock<IAssetSaleTransaction>();
            Capitaladditiontransaction = new Mock<ICapitalAdditionTransaction>();
            Capitaldrawingtransaction = new Mock<ICapitalDrawingTransaction>();
            Expensetransaction = new Mock<IExpenseTransaction>();
            Incometransaction = new Mock<IIncomeTransaction>();
            Liabilitydecreasetransaction = new Mock<ILiabilityDecreaseTransaction>();
            Liabilityincreasetransaction = new Mock<ILiabilityIncreaseTransaction>();
            Repository.As<IAccountRepository>().SetupAllProperties();

            Transaction.Setup(a => a.CreditAccountId).Returns(Testint);
            Repository.Setup(a => a.Find(Transaction.Object.CreditAccountId)).Returns(Entity.Object);
            Transaction.Setup(a => a.DebitAccountId).Returns(Testint);
            Repository.Setup(a => a.Find(Transaction.Object.CreditAccountId)).Returns(Entity.Object);

            sut = new AccountUnityViewModelFactory(
                Repository.Object,
                Container.Object
                );

            Sut = sut;
        }

        [Fact]
        public void ShouldCreateDebitAssetAccountViewModelWhenTransactionIsAssetPurchaseTransaction()
        {
            sut.GetDebitAccountViewModelForTransaction(Assetpurchasetransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<AssetAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateCreditCurrencyAccountViewModelWhenTransactionIsAssetPurchaseTransaction()
        {
            sut.GetCreditAccountViewModelForTransaction(Assetpurchasetransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CurrencyAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateDebitCurrencyAccountViewModelWhenTransactionIsAssetSaleTransaction()
        {
            sut.GetDebitAccountViewModelForTransaction(Assetsaletransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CurrencyAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateCreditAssetAccountViewModelWhenTransactionIsAssetSaleTransaction()
        {
            sut.GetCreditAccountViewModelForTransaction(Assetsaletransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<AssetAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateDebitCurrencyAccountViewModelWhenTransactionIsCapitalAdditionTransaction()
        {
            sut.GetDebitAccountViewModelForTransaction(Capitaladditiontransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CurrencyAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateCreditCapitalAccountViewModelWhenTransactionIsCapitalAdditionTransaction()
        {
            sut.GetCreditAccountViewModelForTransaction(Capitaladditiontransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CapitalAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateDebitCapitalAccountViewModelWhenTransactionIsCapitalDrawingTransaction()
        {
            sut.GetDebitAccountViewModelForTransaction(Capitaldrawingtransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CapitalAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateCreditCurrencyAccountViewModelWhenTransactionIsCapitalDrawingTransaction()
        {
            sut.GetCreditAccountViewModelForTransaction(Capitaldrawingtransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CurrencyAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateDebitExpenseAccountViewModelWhenTransactionIsExpenseTransaction()
        {
            sut.GetDebitAccountViewModelForTransaction(Expensetransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<ExpenseAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateCreditCurrencyAccountViewModelWhenTransactionIsExpenseTransaction()
        {
            sut.GetCreditAccountViewModelForTransaction(Expensetransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CurrencyAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateDebitCurrencyAccountViewModelWhenTransactionIsIncomeTransaction()
        {
            sut.GetDebitAccountViewModelForTransaction(Incometransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CurrencyAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateCreditIncomeAccountViewModelWhenTransactionIsIncomeTransaction()
        {
            sut.GetCreditAccountViewModelForTransaction(Incometransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<IncomeAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateDebitLiabilityAccountViewModelWhenTransactionIsLiabilityDecreaseTransaction()
        {
            sut.GetDebitAccountViewModelForTransaction(Liabilitydecreasetransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<LiabilityAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateCreditCurrencyAccountViewModelWhenTransactionIsLiabilityDecreaseTransaction()
        {
            sut.GetCreditAccountViewModelForTransaction(Liabilitydecreasetransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CurrencyAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateDebitCurrencyAccountViewModelWhenTransactionIsLiabilityIncreaseTransaction()
        {
            sut.GetDebitAccountViewModelForTransaction(Liabilityincreasetransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<CurrencyAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

        [Fact]
        public void ShouldCreateCreditLiabilityAccountViewModelWhenTransactionIsLiabilityIncreaseTransaction()
        {
            sut.GetCreditAccountViewModelForTransaction(Liabilityincreasetransaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<LiabilityAccount>), null, new ResolverOverride[]
            {new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

    }
}
