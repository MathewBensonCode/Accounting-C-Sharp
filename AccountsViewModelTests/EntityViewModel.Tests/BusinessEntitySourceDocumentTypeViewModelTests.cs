using AccountLib.Interfaces;
using Moq;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Xunit;
using AccountLib.Model.Source_Documents;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.BusinessEntitySourceDocumentTypes;

namespace AccountsViewModelTests.EntityViewModel.Tests
{
    public class BusinessEntitySourceDocumentTypeViewModelTests
        : EntityViewModelTests<BusinessEntitySourceDocumentType>
    {
        private readonly IBusinessEntitySourceDocumentType businessentitysourcedocumenttype;
        private readonly string Teststring;
        private int Testint;
        private readonly Mock<IBusinessEntityViewModelFactory> businessEntityViewModelFactory;
        private readonly Mock<IDocumentTypeNameViewModelFactory> documentTypeNameViewModelFactory;
        private readonly BusinessEntitySourceDocumentTypeViewModel sut;

        protected override EntityViewModel<BusinessEntitySourceDocumentType> Sut { get; set; }
        protected override BusinessEntitySourceDocumentType Entity { get; set; }

        public BusinessEntitySourceDocumentTypeViewModelTests()
        {
            Teststring = It.IsAny<string>();
            Testint = It.IsAny<int>();
            Entity = new BusinessEntitySourceDocumentType();
            businessentitysourcedocumenttype = Entity;
            businessEntityViewModelFactory = new Mock<IBusinessEntityViewModelFactory>();
            documentTypeNameViewModelFactory = new Mock<IDocumentTypeNameViewModelFactory>();
            sut = new BusinessEntitySourceDocumentTypeViewModel(
                businessentitysourcedocumenttype,
                ErrorCollection.Object,
                businessEntityViewModelFactory.Object,
                documentTypeNameViewModelFactory.Object
                );

            Sut = sut;
        }

        [Fact]
        public void ShouldImplementIBusinessEntitySourceDocumentTypeViewModel()
        {
            _ = Assert.IsAssignableFrom<IBusinessEntitySourceDocumentTypeViewModel>(sut);
        }

        [Fact]
        public void ShouldSetUnderlyingBusinessEntityIdWhenViewModelEntityIdSet()
        {
            sut.BusinessEntityId = Testint;
            Assert.Equal(Testint, businessentitysourcedocumenttype.BusinessEntityId);
        }

        [Fact]
        public void ShouldReturnUnderlyingBusinessEntityIdThroughViewModelBusinessEntityIdProperty()
        {
            businessentitysourcedocumenttype.BusinessEntityId = Testint;
            Assert.Equal(Testint, sut.BusinessEntityId);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenBusinessEntityIdPropertySet()
        {
            Assert.PropertyChanged(sut, "BusinessEntityId", () => { sut.BusinessEntityId = Testint; });
        }

        [Fact]
        public void ShouldSetUnderlyingDocumentTypeNameIdWhenViewModelEntityIdSet()
        {
            Testint = 4;
            sut.DocumentTypeNameId = Testint;
            Assert.Equal(Testint, businessentitysourcedocumenttype.DocumentTypeNameId);
        }

        [Fact]
        public void ShouldReturnUnderlyingDocumentTypeNameIdThroughViewModelDocumentTypeNameIdProperty()
        {
            businessentitysourcedocumenttype.DocumentTypeNameId = Testint;
            Assert.Equal(Testint, sut.DocumentTypeNameId);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenDocumentTypeNameIdPropertySet()
        {
            Testint = 3;
            Assert.PropertyChanged(sut, "DocumentTypeNameId", () => { sut.DocumentTypeNameId = Testint; });
        }

        [Fact]
        public void ShouldSetUnderlyingDateRegexWhenViewModelEntityIdSet()
        {
            sut.DateRegex = Teststring;
            Assert.Equal(Teststring, businessentitysourcedocumenttype.DateRegex);
        }

        [Fact]
        public void ShouldReturnUnderlyingDateRegexThroughViewModelDateRegexProperty()
        {
            businessentitysourcedocumenttype.DateRegex = Teststring;
            Assert.Equal(Teststring, sut.DateRegex);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenDateRegexPropertySet()
        {
            Assert.PropertyChanged(sut, "DateRegex", () => { sut.DateRegex = Teststring; });
        }

        [Fact]
        public void ShouldSetUnderlyingDocumentTypeNameRegexWhenViewModelEntityIdSet()
        {
            sut.DocumentTypeNameRegex = Teststring;
            Assert.Equal(Teststring, businessentitysourcedocumenttype.DocumentTypeNameRegex);
        }

        [Fact]
        public void ShouldReturnUnderlyingDocumentTypeNameRegexThroughViewModelDocumentTypeNameRegexProperty()
        {
            businessentitysourcedocumenttype.DocumentTypeNameRegex = Teststring;
            Assert.Equal(Teststring, sut.DocumentTypeNameRegex);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenDocumentTypeNameRegexPropertySet()
        {
            Assert.PropertyChanged(sut, "DocumentTypeNameRegex", () => { sut.DocumentTypeNameRegex = Teststring; });
        }

        [Fact]
        public void ShouldSetUnderlyingItemNameRegexWhenViewModelEntityIdSet()
        {
            var newteststring = "setItemNameRegex";
            sut.ItemNameRegex = newteststring;
            Assert.Equal(newteststring, businessentitysourcedocumenttype.ItemNameRegex);
        }

        [Fact]
        public void ShouldReturnUnderlyingItemNameRegexThroughViewModelItemNameRegexProperty()
        {
            businessentitysourcedocumenttype.ItemNameRegex = Teststring;
            Assert.Equal(Teststring, sut.ItemNameRegex);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenItemNameRegexPropertySet()
        {
            Assert.PropertyChanged(sut, "ItemNameRegex", () => { sut.ItemNameRegex = Teststring; });
        }

        [Fact]
        public void ShouldSetUnderlyingItemUnitCostRegexWhenViewModelEntityIdSet()
        {
            var newteststring = "SetItemUnitCostRegex";
            sut.ItemUnitCostRegex = newteststring;
            Assert.Equal(newteststring, businessentitysourcedocumenttype.ItemUnitCostRegex);
        }

        [Fact]
        public void ShouldReturnUnderlyingItemUnitCostRegexThroughViewModelItemUnitCostRegexProperty()
        {
            businessentitysourcedocumenttype.ItemUnitCostRegex = Teststring;
            Assert.Equal(Teststring, sut.ItemUnitCostRegex);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenItemUnitCostRegexPropertySet()
        {
            Assert.PropertyChanged(sut, "ItemUnitCostRegex", () => { sut.ItemUnitCostRegex = Teststring; });
        }

        [Fact]
        public void ShouldSetUnderlyingItemQuantityRegexWhenViewModelEntityIdSet()
        {
            var newteststring = "SetItemQuantityRegex";
            sut.ItemQuantityRegex = newteststring;
            Assert.Equal(newteststring, businessentitysourcedocumenttype.ItemQuantityRegex);
        }

        [Fact]
        public void ShouldReturnUnderlyingItemQuantityRegexThroughViewModelItemQuantityRegexProperty()
        {
            businessentitysourcedocumenttype.ItemQuantityRegex = Teststring;
            Assert.Equal(Teststring, sut.ItemQuantityRegex);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenItemQuantityRegexPropertySet()
        {
            Assert.PropertyChanged(sut, "ItemQuantityRegex", () => { sut.ItemQuantityRegex = Teststring; });
        }

        [Fact]
        public void ShouldSetUnderlyingItemTotalCostRegexWhenViewModelEntityIdSet()
        {
            var newteststring = "SetItemTotalCostRegex";
            sut.ItemTotalCostRegex = newteststring;
            Assert.Equal(newteststring, businessentitysourcedocumenttype.ItemTotalCostRegex);
        }

        [Fact]
        public void ShouldReturnUnderlyingItemTotalCostRegexThroughViewModelItemTotalCostRegexProperty()
        {
            businessentitysourcedocumenttype.ItemTotalCostRegex = Teststring;
            Assert.Equal(Teststring, sut.ItemTotalCostRegex);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenItemTotalCostRegexPropertySet()
        {
            Assert.PropertyChanged(sut, "ItemTotalCostRegex", () => { sut.ItemTotalCostRegex = Teststring; });
        }

        [Fact]
        public void ShouldSetUnderlyingBusinessEntityItemReferenceRegexWhenViewModelEntityIdSet()
        {
            var newteststring = "SetBusinessEntityItemReferenceRegex";
            sut.BusinessEntityItemReferenceRegex = newteststring;
            Assert.Equal(newteststring, businessentitysourcedocumenttype.BusinessEntityItemReferenceRegex);
        }

        [Fact]
        public void ShouldReturnUnderlyingBusinessEntityItemReferenceRegexThroughViewModelBusinessEntityItemReferenceRegexProperty()
        {
            businessentitysourcedocumenttype.BusinessEntityItemReferenceRegex = Teststring;
            Assert.Equal(Teststring, sut.BusinessEntityItemReferenceRegex);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenBusinessEntityItemReferenceRegexPropertySet()
        {
            Assert.PropertyChanged(sut, "BusinessEntityItemReferenceRegex", () => { sut.BusinessEntityItemReferenceRegex = Teststring; });
        }

        [Fact]
        public void ShouldSetUnderlyingTransactionRegexWhenViewModelEntityIdSet()
        {
            var newteststring = "SetTransactionRegex";
            sut.TransactionRegex = newteststring;
            Assert.Equal(newteststring, businessentitysourcedocumenttype.TransactionRegex);
        }

        [Fact]
        public void ShouldReturnUnderlyingTransactionRegexThroughViewModelTransactionRegexProperty()
        {
            businessentitysourcedocumenttype.TransactionRegex = Teststring;
            Assert.Equal(Teststring, sut.TransactionRegex);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenTransactionRegexPropertySet()
        {
            Assert.PropertyChanged(sut, "TransactionRegex", () => { sut.TransactionRegex = Teststring; });
        }

        [Fact]
        public void ShouldHaveAPropertyForIBusinessEntityViewModelFromTheBusinessEntityId()
        {
            businessentitysourcedocumenttype.BusinessEntityId = Testint;
            var temp = sut.BusinessEntity;
            businessEntityViewModelFactory
                .Verify(a => a.GetBusinessEntityViewModelForBusinessEntitySourceDocumentType(businessentitysourcedocumenttype)
                , Times.Once);
        }

        [Fact]
        public void ShouldHaveAPropertyForIDocumentTypeNameViewModelFromTheDocumentTypeNameId()
        {
            businessentitysourcedocumenttype.DocumentTypeNameId = Testint;
            var temp = sut.DocumentTypeName;
            documentTypeNameViewModelFactory
                .Verify(a => a.GetDocumentTypeNameViewModelForBusinessEntitySourceDocumentType(businessentitysourcedocumenttype),
                Times.Once);
        }

    }
}
