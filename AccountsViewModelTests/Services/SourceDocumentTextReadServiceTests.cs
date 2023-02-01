using System.Collections.Generic;
using System.Text.RegularExpressions;
using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Classes;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.RegexFactories;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Services;
using AccountsViewModel.Services.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.Services
{
    public class SourceDocumentTextReadServiceTests
    {
        private readonly Mock<IEntityCollectionViewModel<BusinessEntity>> businessEntityCollectionViewModel;
        private readonly Mock<ICollectionListViewModelState<BusinessEntity>> businessEntityListCollectionViewModelState;
        private readonly ICollection<IEntityViewModel<BusinessEntity>> businessEntityViewModelCollection;

        private readonly Mock<IEntityCollectionViewModel<BusinessEntitySourceDocumentType>> businessEntitySourceDocumentTypeCollectionViewModel;
        private readonly Mock<IRegexFactory> regexFactory;

        private readonly Mock<IBusinessEntityViewModel> businessEntityViewModel1;
        private readonly Mock<IEntityViewModel<BusinessEntity>> businessentityviewmodel1;
        private readonly Mock<IBusinessEntityViewModel> businessEntityViewModel2;

        private readonly Mock<ICollection<Transaction>> transactionCollection;
        private readonly Mock<IBusinessEntitySourceDocumentTypeViewModel> businessEntitySourceDocumentTypeViewModel1;
        private readonly Mock<ISourceDocumentViewModel> sourceDocumentViewModel;
        private readonly Mock<IViewModelFactory<Transaction>> transactionvmfactory;
        private readonly Mock<ITransactionViewModel> transactionvm;
        private readonly Mock<ISourceDocumentCollectionAddEditViewModelState> sourceDocumentAddEditCollectionViewModelState;

        private readonly Mock<SourceDocument> sourceDocument;

        private readonly SourceDocumentTextReadService sut;

        private readonly string DateRegex = @"\d{2}-\d{2}-\d{4}\s\d{2}:\d{2}:\d{2}";
        private readonly string ItemNameRegex = @"(\w+|\s|[']|[/])+";
        private readonly string ItemUnitCostRegex = @"x\s\d+[.]\d{2}";
        private readonly string ItemQuantityRegex = @"\sd+\sx";
        private readonly string ItemTotalCostRegex = @"\d+[.]\d{2}";
        private readonly string TransactionRegex = @"^\d{12}(\s\d+\sx\s\d+[.]\d{2})?(\s+(\w+|\s|[']|[/])+\s+\d+[.]\d{2}\s\w{1})";

        private readonly string DocumentTypeNameRegex1 = @"NON\sFISCAL\sRECEIPT";
        private readonly string DocumentTypeNameRegex2 = @"FISCAL\sRECEIPT";
        private readonly string DocumentTypeNameRegex3 = @"INVOICE";

        public SourceDocumentTextReadServiceTests()
        {
            regexFactory = new Mock<IRegexFactory>();

            sourceDocumentViewModel = new Mock<ISourceDocumentViewModel>();
            sourceDocumentAddEditCollectionViewModelState = new Mock<ISourceDocumentCollectionAddEditViewModelState>();
            _ = sourceDocumentAddEditCollectionViewModelState.Setup(a => a.EntityViewModel)
                .Returns(sourceDocumentViewModel.Object);
            _ = sourceDocumentAddEditCollectionViewModelState.Setup(a => a.SourceDocumentText)
                .Returns(SampleDocument.Text);

            transactionCollection = new Mock<ICollection<Transaction>>();

            sourceDocument = new Mock<SourceDocument>();
            _ = sourceDocument.Setup(a => a.Transactions)
                .Returns(transactionCollection.Object);
            sourceDocumentViewModel = new Mock<ISourceDocumentViewModel>();
            _ = sourceDocumentViewModel.Setup(a => a.Entity)
                .Returns(sourceDocument.Object);

            transactionvmfactory = new Mock<IViewModelFactory<Transaction>>();
            transactionvm = new Mock<ITransactionViewModel>();

            _ = transactionvmfactory.Setup(a => a.CreateViewModelForNewEntity(null))
                .Returns(transactionvm.Object);

            businessEntityCollectionViewModel = new Mock<IEntityCollectionViewModel<BusinessEntity>>();
            businessEntityListCollectionViewModelState = new Mock<ICollectionListViewModelState<BusinessEntity>>();
            _ = businessEntityCollectionViewModel.Setup(a => a.CollectionViewState)
                .Returns(businessEntityListCollectionViewModelState.Object);

            _ = sourceDocumentAddEditCollectionViewModelState.Setup(a => a.BusinessEntityCollectionViewModel)
                .Returns(businessEntityCollectionViewModel.Object);

            businessEntitySourceDocumentTypeCollectionViewModel = new Mock<IEntityCollectionViewModel<BusinessEntitySourceDocumentType>>();

            businessEntityViewModel1 = new Mock<IBusinessEntityViewModel>();
            _ = businessEntityViewModel1.Setup(a => a.Name)
                .Returns("majid al futtaim(Carrefour)");
            _ = businessEntityViewModel1.Setup(a => a.BusinessEntityNameRegex)
                .Returns("Carrefour");
            _ = businessEntityViewModel1.Setup(a => a.Id).Returns(1);
            _ = businessEntityViewModel1.Setup(a => a.BusinessEntitySourceDocumentTypes)
                 .Returns(businessEntitySourceDocumentTypeCollectionViewModel.Object);

            businessEntityViewModel2 = new Mock<IBusinessEntityViewModel>();
            _ = businessEntityViewModel2.Setup(a => a.Name)
                .Returns("VADO GENERAL HARDWARE");
            _ = businessEntityViewModel2.Setup(a => a.BusinessEntityNameRegex)
                .Returns("VADO");
            _ = businessEntityViewModel2.Setup(a => a.Id).Returns(2);
            _ = businessEntityViewModel2.Setup(a => a.BusinessEntitySourceDocumentTypes)
                 .Returns(businessEntitySourceDocumentTypeCollectionViewModel.Object);

            businessentityviewmodel1 = businessEntityViewModel1.As<IEntityViewModel<BusinessEntity>>();

            businessEntityViewModelCollection = new List<IEntityViewModel<BusinessEntity>>
            {
                businessentityviewmodel1.Object,
                businessEntityViewModel2.As<IEntityViewModel<BusinessEntity>>().Object
            };

            _ = businessEntityListCollectionViewModelState.Setup(a => a.EntityCollection)
                .Returns(businessEntityViewModelCollection);

            _ = businessEntityListCollectionViewModelState.SetupProperty(a => a.EntityViewModel);

            businessEntitySourceDocumentTypeViewModel1 = new Mock<IBusinessEntitySourceDocumentTypeViewModel>();

            _ = businessEntitySourceDocumentTypeViewModel1.Setup(a => a.DateRegex)
                .Returns(DateRegex);
            _ = businessEntitySourceDocumentTypeViewModel1.Setup(a => a.ItemNameRegex)
                .Returns(ItemNameRegex);
            _ = businessEntitySourceDocumentTypeViewModel1.Setup(a => a.ItemUnitCostRegex)
                .Returns(ItemUnitCostRegex);
            _ = businessEntitySourceDocumentTypeViewModel1.Setup(a => a.ItemQuantityRegex)
                .Returns(ItemQuantityRegex);
            _ = businessEntitySourceDocumentTypeViewModel1.Setup(a => a.ItemTotalCostRegex)
                .Returns(ItemTotalCostRegex);
            _ = businessEntitySourceDocumentTypeViewModel1.Setup(a => a.TransactionRegex)
                .Returns(TransactionRegex);

            _ = regexFactory.Setup(a => a.CreateRegex(businessEntityViewModel1.Object.BusinessEntityNameRegex))
                .Returns(new Regex(businessEntityViewModel1.Object.BusinessEntityNameRegex));
            _ = regexFactory.Setup(a => a.CreateRegex(businessEntityViewModel2.Object.BusinessEntityNameRegex))
                .Returns(new Regex(businessEntityViewModel2.Object.BusinessEntityNameRegex));

            _ = sourceDocumentViewModel.Setup(a => a.BusinessEntitySourceDocumentTypeViewModel)
    .Returns(businessEntitySourceDocumentTypeViewModel1.Object);

            _ = regexFactory.Setup(a => a.CreateRegex(businessEntitySourceDocumentTypeViewModel1.Object.DateRegex)).
                Returns(new Regex(businessEntitySourceDocumentTypeViewModel1.Object.DateRegex));
            _ = regexFactory.Setup(a => a.CreateRegex(businessEntitySourceDocumentTypeViewModel1.Object.ItemNameRegex)).
                Returns(new Regex(businessEntitySourceDocumentTypeViewModel1.Object.ItemNameRegex));
            _ = regexFactory.Setup(a => a.CreateRegex(businessEntitySourceDocumentTypeViewModel1.Object.ItemUnitCostRegex)).
                Returns(new Regex(businessEntitySourceDocumentTypeViewModel1.Object.ItemUnitCostRegex));
            _ = regexFactory.Setup(a => a.CreateRegex(businessEntitySourceDocumentTypeViewModel1.Object.ItemQuantityRegex)).
                Returns(new Regex(businessEntitySourceDocumentTypeViewModel1.Object.ItemQuantityRegex));
            _ = regexFactory.Setup(a => a.CreateRegex(businessEntitySourceDocumentTypeViewModel1.Object.ItemTotalCostRegex)).
                Returns(new Regex(businessEntitySourceDocumentTypeViewModel1.Object.ItemTotalCostRegex));
            _ = regexFactory.Setup(a => a.CreateRegex(businessEntitySourceDocumentTypeViewModel1.Object.TransactionRegex)).
                Returns(new Regex(businessEntitySourceDocumentTypeViewModel1.Object.TransactionRegex, RegexOptions.Multiline));

            _ = regexFactory.Setup(a => a.CreateRegex(DocumentTypeNameRegex1))
                .Returns(new Regex(DocumentTypeNameRegex1));
            _ = regexFactory.Setup(a => a.CreateRegex(DocumentTypeNameRegex2))
                .Returns(new Regex(DocumentTypeNameRegex2));
            _ = regexFactory.Setup(a => a.CreateRegex(DocumentTypeNameRegex3))
                .Returns(new Regex(DocumentTypeNameRegex3));

            sut = new SourceDocumentTextReadService(
                  regexFactory.Object
            );
        }

        [Fact]
        public void ShouldImplementISourceDocumentTextReadService()
        {
            _ = Assert.IsAssignableFrom<ISourceDocumentTextReadService>(sut);
        }

        [Fact]
        public void ShouldFindBusinessEntityFromText()
        {

            sut.GetDetailsFromText(sourceDocumentAddEditCollectionViewModelState.Object);
            var entity = sourceDocumentAddEditCollectionViewModelState.Object.BusinessEntityCollectionViewModel.CollectionViewState.EntityViewModel;
            Assert.Same(businessEntityViewModel1.Object, entity);

        }

        [Fact]
        public void ShouldReturnNullFromFindBusinessEntityFromTextWhenNoMatchFound()
        {
            businessEntityViewModelCollection.Remove(businessentityviewmodel1.Object);
            sut.GetDetailsFromText(sourceDocumentAddEditCollectionViewModelState.Object);
            var entity = sourceDocumentAddEditCollectionViewModelState.Object.BusinessEntityCollectionViewModel.CollectionViewState.EntityViewModel;
            Assert.Null(entity);
        }

        //        [Fact]
        //        public void ShouldFindBusinessEntitySourceDocumentTypeFromCollectionInBusinessEntity()
        //        {
        //            var documenttype = sut.GetBusinessEntitySourceDocumentTypeFromText(SampleDocument.Text, (IBusinessEntity)businessentityviewmodel1.Object);
        //            Assert.Equal(businessEntitySourceDocumentCollection[1], documenttype);
        //        }

        //[Fact]
        //public void ShouldReturnNullIfBusinessEntitySourceDocumentTypeNotFoundForText()
        //{
        //Assert.Null(sut.GetBusinessEntitySourceDocumentTypeFromText("just a string", businessEntityViewModel.Object));

        //}

        //[Fact]
        //public void ShouldcreateDateRegexFromBusinessEntitySourceDocumentType()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //regexFactory.Verify(a => a.CreateRegex(businessEntitySourceDocumentType.Object.DateRegex));
        //}

        //[Fact]
        //public void ShouldcreateItemNameRegexFromBusinessEntitySourceDocumentType()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //regexFactory.Verify(a => a.CreateRegex(businessEntitySourceDocumentType.Object.ItemNameRegex));
        //}

        //[Fact]
        //public void ShouldcreateItemUnitCostRegexFromBusinessEntitySourceDocumentType()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //regexFactory.Verify(a => a.CreateRegex(businessEntitySourceDocumentType.Object.ItemUnitCostRegex));
        //}

        //[Fact]
        //public void ShouldcreateItemQuantityRegexFromBusinessEntitySourceDocumentType()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //regexFactory.Verify(a => a.CreateRegex(businessEntitySourceDocumentType.Object.ItemQuantityRegex));
        //}

        //[Fact]
        //public void ShouldcreateItemTotalCostRegexFromBusinessEntitySourceDocumentType()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //regexFactory.Verify(a => a.CreateRegex(businessEntitySourceDocumentType.Object.ItemTotalCostRegex));
        //}

        //[Fact]
        //public void ShouldcreateBusinessEntityItemReferenceRegexFromBusinessEntitySourceDocumentType()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //regexFactory.Verify(a => a.CreateRegex(businessEntitySourceDocumentType.Object.BusinessEntityItemReferenceRegex));
        //}

        //[Fact]
        //public void ShouldcreateTransactionRegexFromBusinessEntitySourceDocumentType()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //regexFactory.Verify(a => a.CreateRegex(businessEntitySourceDocumentType.Object.TransactionRegex));
        //}

        //[Theory]
        //[InlineData(499.00)]
        //[InlineData(79.00)]
        //[InlineData(476.00)]
        //public void ShouldSetTransactionViewModelAmountFromImageText(decimal amount)
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //transactionvm.VerifySet(a => a.Amount = amount);
        //}

        //[Fact]
        //public void ShouldSetSourceDocumentViewModelDateFromText()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //sourceDocumentViewModel.VerifySet(a => a.DocumentDate = testdate);
        //}

        //[Fact]
        //public void ShouldReadAndCreateAllTransactionsFromText()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //transactionvmfactory.Verify(a => a.CreateViewModelForNewEntity(It.IsAny<string>()), Times.Exactly(19));
        //}

        //[Fact]
        //public void ShouldAddTransactionsToSourceDocumentViewModelCollection()
        //{
        //sut.GetTransactionsFromText(SampleDocument.Text, sourceDocumentViewModel.Object);
        //transactionCollection.Verify(a => a.Add(transactionvm.Object.Entity as Transaction), Times.Exactly(19));
        //}

    }

}
