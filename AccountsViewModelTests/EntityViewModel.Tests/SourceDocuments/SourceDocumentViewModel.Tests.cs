using AccountLib.Model.SourceDocuments;
using AccountLib.Interfaces.SourceDocuments;
using Moq;
using System;
using Xunit;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountLib.Model.Transactions;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.SourceDocuments;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;

namespace AccountsViewModelTests.EntityViewModel.Tests.SourceDocuments
{
    public class SourceDocumentViewModelTests
        : EntityViewModelTests<SourceDocument>
    {
        private readonly SourceDocumentViewModel SourceDocumentSut;
        private readonly ISourceDocument sourcedocument;
        private readonly Mock<ITransactionChildCollectionViewModelFactory> transactionCollectionViewModelFactory;
        private readonly Mock<IImageChildCollectionViewModelFactory> imageChildCollectionViewModelFactory;
        private readonly Mock<IBusinessEntitySourceDocumentTypeViewModelFactory> BusinessEntitySourceDocumentTypeViewModelFactory;
        private readonly Mock<IEntityCollectionViewModel<Transaction>> transactioncollectionviewmodel;
        private readonly DateTime TestDate;

        protected override EntityViewModel<SourceDocument> Sut { get; set; }
        protected override SourceDocument Entity { get; set; }

        public SourceDocumentViewModelTests()
        {
            Entity = new SourceDocument();
            sourcedocument = Entity;
            transactionCollectionViewModelFactory = new Mock<ITransactionChildCollectionViewModelFactory>();
            BusinessEntitySourceDocumentTypeViewModelFactory = new Mock<IBusinessEntitySourceDocumentTypeViewModelFactory>();
            imageChildCollectionViewModelFactory = new Mock<IImageChildCollectionViewModelFactory>();
            TestDate = DateTime.Now;
            transactioncollectionviewmodel = new Mock<IEntityCollectionViewModel<Transaction>>();

            _ = transactionCollectionViewModelFactory.Setup(a => a.GetTransactionCollectionViewModelForSourceDocument(sourcedocument))
                .Returns(transactioncollectionviewmodel.Object);

            SourceDocumentSut = new SourceDocumentViewModel(
                sourcedocument,
                transactionCollectionViewModelFactory.Object,
                BusinessEntitySourceDocumentTypeViewModelFactory.Object,
                imageChildCollectionViewModelFactory.Object,
                ErrorCollection.Object
                );

            Sut = SourceDocumentSut;
        }

        [Fact]
        public void ShouldImplementISourceDocumentViewModel()
        {
            _ = Assert.IsAssignableFrom<ISourceDocumentViewModel>(SourceDocumentSut);
        }

        [Fact]
        public void GetsUnderlyingDocumentDateThroughDocumentDateProperty()
        {
            sourcedocument.DocumentDate = TestDate;
            Assert.Equal(TestDate, SourceDocumentSut.DocumentDate);
        }

        [Fact]
        public void SetsUnderlyingDocumentDateWhenDocumentDatePropertySet()
        {
            SourceDocumentSut.DocumentDate = TestDate;
            Assert.Equal(TestDate, sourcedocument.DocumentDate);
        }

        [Fact]
        public void RaisesPropertyChangedEventWhenDocumentDatePropertySet()
        {
            Assert.PropertyChanged(SourceDocumentSut, "DocumentDate", () => { SourceDocumentSut.DocumentDate = TestDate; });
        }

        [Fact]
        public void GetsUnderlyingBusinessEntitySourceDocumentTypeIdThroughBusinessEntitySourceDocumentTypeSourceDocumentTypeIdProperty()
        {
            var TestId = 5;
            sourcedocument.BusinessEntitySourceDocumentTypeId = TestId;
            Assert.Equal(TestId, SourceDocumentSut.BusinessEntitySourceDocumentTypeId);
        }

        [Fact]
        public void SetsUnderlyingBusinessEntitySourceDocumentTypeIdWhenBusinessEntitySourceDocumentTypeIdPropertySet()
        {
            var TestId = 3;
            SourceDocumentSut.BusinessEntitySourceDocumentTypeId = TestId;
            Assert.Equal(TestId, sourcedocument.BusinessEntitySourceDocumentTypeId);
        }

        [Fact]
        public void RaisesPropertyChangedEventWhenBusinessEntitySourceDocumentTypeIdPropertyChanged()
        {
            var TestId = It.IsAny<int>();
            Assert.PropertyChanged(SourceDocumentSut, "BusinessEntitySourceDocumentTypeId", () => { SourceDocumentSut.BusinessEntitySourceDocumentTypeId = TestId; });
        }

        [Fact]
        public void TransactionCollectionViewModelPropertyShouldNotBeNull()
        {
            Assert.Same(transactioncollectionviewmodel.Object, SourceDocumentSut.TransactionCollectionViewModel);
        }

        [Fact]
        public void ShouldCreateBusinessEntitySourceDocumentTypeViewModelForCurrentBusinessEntitySourceDocumentTypeId()
        {
            var testid = 7;
            sourcedocument.BusinessEntitySourceDocumentTypeId = testid;
            var temp = SourceDocumentSut.BusinessEntitySourceDocumentTypeViewModel;
            BusinessEntitySourceDocumentTypeViewModelFactory
              .Verify(a => a.GetBusinessEntitySourceDocumentTypeViewModelForSourceDocument(sourcedocument)
              , Times.Once);
        }

        [Fact]
        public void ShouldRaisePropertyChangedNotificationForBusinessEntitySourceDocumentTypeViewModelWhenBusinessEntitySourceDocumentTypeIdIsChanged()
        {
            var testid = 8;
            Assert.PropertyChanged(SourceDocumentSut, "BusinessEntitySourceDocumentTypeViewModel", () => { SourceDocumentSut.BusinessEntitySourceDocumentTypeId = testid; });
        }

    }
}
