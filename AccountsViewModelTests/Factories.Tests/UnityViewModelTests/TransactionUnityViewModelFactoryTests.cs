using AccountLib.Model.Transactions;
using System;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces;
using AccountsViewModel.Factories.Unity.ViewModelFactories;
using Xunit;
using AccountsViewModel.EntityViewModels.Classes.Transactions;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;

namespace AccountsViewModelTests.Factories.Tests.UnityViewModelTests
{
    public class TransactionUnityViewModelFactoryTests :
        UnityViewModelFactoryTests<Transaction>
    {
        private readonly AssetPurchaseTransactionViewModel assetpurchasetransactionviewmodel;
        private readonly AssetSaleTransactionViewModel assetsaletransactionviewmodel;
        private readonly CapitalAdditionTransactionViewModel capitaladditiontransactionviewmodel;
        private readonly CapitalDrawingTransactionViewModel capitaldrawingtransactionviewmodel;
        private readonly ExpenseTransactionViewModel expensetransactionviewmodel;
        private readonly IncomeTransactionViewModel incometransactionviewmodel;
        private readonly LiabilityIncreaseTransactionViewModel liabilityincreasetransactionviewmodel;
        private readonly LiabilityDecreaseTransactionViewModel liabilitydecreasetransactionviewmodel;

        private readonly AssetPurchaseTransaction assetpurchasetransaction;
        private readonly AssetSaleTransaction assetsaletransaction;
        private readonly CapitalAdditionTransaction capitaladditiontransaction;
        private readonly CapitalDrawingTransaction capitaldrawingtransaction;
        private readonly ExpenseTransaction expensetransaction;
        private readonly IncomeTransaction incometransaction;
        private readonly LiabilityIncreaseTransaction liabilityincreasetransaction;
        private readonly LiabilityDecreaseTransaction liabilitydecreasetransaction;

        private readonly Mock<IAccountViewModelFactory> accountviewmodelfactory;
        private readonly Mock<ISourceDocumentViewModelFactory> sourcedocumentviewmodelfactory;
        private readonly Mock<IDictionary<string, List<string>>> errors;

        private readonly TransactionUnityViewModelFactory sut;

        protected override UnityViewModelFactory<Transaction> Sut { get; set; }

        public TransactionUnityViewModelFactoryTests()
        {
            assetpurchasetransaction = new();
            assetsaletransaction = new();
            capitaladditiontransaction = new();
            capitaldrawingtransaction = new();
            expensetransaction = new();
            incometransaction = new();
            liabilityincreasetransaction = new();
            liabilitydecreasetransaction = new();

            accountviewmodelfactory = new();
            sourcedocumentviewmodelfactory = new();
            errors = new();

            assetpurchasetransactionviewmodel = new AssetPurchaseTransactionViewModel(
                    assetpurchasetransaction,
                    accountviewmodelfactory.Object,
                    sourcedocumentviewmodelfactory.Object,
                    errors.Object
                    );

            assetsaletransactionviewmodel = new AssetSaleTransactionViewModel(
                      assetsaletransaction,
                      accountviewmodelfactory.Object,
                      sourcedocumentviewmodelfactory.Object,
                      errors.Object
                      );

            capitaladditiontransactionviewmodel = new CapitalAdditionTransactionViewModel(
                      capitaladditiontransaction,
                      accountviewmodelfactory.Object,
                      sourcedocumentviewmodelfactory.Object,
                      errors.Object
                      );

            capitaldrawingtransactionviewmodel = new CapitalDrawingTransactionViewModel(
                      capitaldrawingtransaction,
                      accountviewmodelfactory.Object,
                      sourcedocumentviewmodelfactory.Object,
                      errors.Object
                      );

            expensetransactionviewmodel = new ExpenseTransactionViewModel(
                      expensetransaction,
                      accountviewmodelfactory.Object,
                      sourcedocumentviewmodelfactory.Object,
                      errors.Object
                      );

            incometransactionviewmodel = new IncomeTransactionViewModel(
                      incometransaction,
                      accountviewmodelfactory.Object,
                      sourcedocumentviewmodelfactory.Object,
                      errors.Object
                      );

            liabilityincreasetransactionviewmodel = new LiabilityIncreaseTransactionViewModel(
                      liabilityincreasetransaction,
                      accountviewmodelfactory.Object,
                      sourcedocumentviewmodelfactory.Object,
                      errors.Object
                      );

            liabilitydecreasetransactionviewmodel = new LiabilityDecreaseTransactionViewModel(
                      liabilitydecreasetransaction,
                      accountviewmodelfactory.Object,
                      sourcedocumentviewmodelfactory.Object,
                      errors.Object
                      );

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<Transaction>), "AssetPurchaseTransaction"))
                .Returns(assetpurchasetransactionviewmodel);

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<Transaction>), "AssetSaleTransaction"))
               .Returns(assetsaletransactionviewmodel);

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<Transaction>), "CapitalAdditionTransaction"))
               .Returns(capitaladditiontransactionviewmodel);

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<Transaction>), "CapitalDrawingTransaction"))
               .Returns(capitaldrawingtransactionviewmodel);

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<Transaction>), "ExpenseTransaction"))
               .Returns(expensetransactionviewmodel);

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<Transaction>), "IncomeTransaction"))
               .Returns(incometransactionviewmodel);

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<Transaction>), "LiabilityIncreaseTransaction"))
               .Returns(liabilityincreasetransactionviewmodel);

            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<Transaction>), "LiabilityDecreaseTransaction"))
              .Returns(liabilitydecreasetransactionviewmodel);

            sut = new TransactionUnityViewModelFactory(
                Container.Object
                );

            Sut = sut;
        }

        [Fact]
        public void ShouldBeAnIViewModelFactory()
        {
            _ = Assert.IsAssignableFrom<IViewModelFactory<Transaction>>(sut);
        }

        [Fact]
        public override void ShouldCreateViewModelFromResolveMethod()
        {
        }

        [Fact]
        public override void ShouldCreateViewmodelFromResolveMethodWithNameParameter()
        {
        }

        [Fact]
        public override void ShouldCreateViewModelFromExistingEntity()
        {
        }

        [Fact]
        public void ShouldCreateAssetPurchaseTransactionWithMatchingParameter()
        {
            var resultentity = sut.CreateViewModelForNewEntity("AssetPurchaseTransaction");
            Assert.Same(assetpurchasetransactionviewmodel, resultentity);
        }

        [Fact]
        public void ShouldCreateAssetSaleTransactionWithMatchingParameter()
        {
            var resultentity = sut.CreateViewModelForNewEntity("AssetSaleTransaction");
            Assert.Same(assetsaletransactionviewmodel, resultentity);
        }

        [Fact]
        public void ShouldCreateCapitalAdditionTransactionWithMatchingParameter()
        {
            var resultentity = sut.CreateViewModelForNewEntity("CapitalAdditionTransaction");
            Assert.Same(capitaladditiontransactionviewmodel, resultentity);
        }

        [Fact]
        public void ShouldCreateCapitalDrawingTransactionWithMatchingParameter()
        {
            var resultentity = sut.CreateViewModelForNewEntity("CapitalDrawingTransaction");
            Assert.Same(capitaldrawingtransactionviewmodel, resultentity);
        }

        [Fact]
        public void ShouldCreateExpenseTransactionWithMatchingParameter()
        {
            var resultentity = sut.CreateViewModelForNewEntity("ExpenseTransaction");
            Assert.Same(expensetransactionviewmodel, resultentity);
        }

        [Fact]
        public void ShouldCreateIncomeTransactionWithMatchingParameter()
        {
            var resultentity = sut.CreateViewModelForNewEntity("IncomeTransaction");
            Assert.Same(incometransactionviewmodel, resultentity);
        }

        [Fact]
        public void ShouldCreateLiabilityIncreaseTransactionWithMatchingParameter()
        {
            var resultentity = sut.CreateViewModelForNewEntity("LiabilityIncreaseTransaction");
            Assert.Same(liabilityincreasetransactionviewmodel, resultentity);
        }

        [Fact]
        public void ShouldCreateLiabilityDecreaseTransactionWithMatchingParameter()
        {
            var resultentity = sut.CreateViewModelForNewEntity("LiabilityDecreaseTransaction");
            Assert.Same(liabilitydecreasetransactionviewmodel, resultentity);
        }
    }
}
