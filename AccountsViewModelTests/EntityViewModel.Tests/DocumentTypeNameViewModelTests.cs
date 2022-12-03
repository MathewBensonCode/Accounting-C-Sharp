using AccountLib.Interfaces;
using AccountLib.Model;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.BusinessEntitySourceDocumentTypes;
using AccountsViewModel.EntityViewModels.Interfaces;
using Xunit;

namespace AccountsViewModelTests.EntityViewModel.Tests
{
    public class DocumentTypeNameViewModelTests :
        EntityViewModelTests<DocumentTypeName>
    {
        private readonly IDocumentTypeName documenttypename;
        private readonly string Teststring;
        private readonly DocumentTypeNameViewModel sut;

        protected override EntityViewModel<DocumentTypeName> Sut { get; set; }
        protected override DocumentTypeName Entity { get; set; }

        public DocumentTypeNameViewModelTests()
        {
            Entity = new DocumentTypeName();
            documenttypename = Entity;
            Teststring = "teststring";

            sut = new DocumentTypeNameViewModel(
                documenttypename,
                ErrorCollection.Object
                );

            Sut = sut;
        }

        [Fact]
        public void ShouldImplementIDocumentTypeNameViewModel()
        {
            _ = Assert.IsAssignableFrom<IDocumentTypeNameViewModel>(sut);
        }

        [Fact]
        public void ShouldSetUnderlyingEntityNameWhenViewModelNameSet()
        {
            var newteststring = "SetName";
            sut.Name = newteststring;
            Assert.Equal(newteststring, documenttypename.Name);
        }

        [Fact]
        public void ShouldReturnUnderlyingNameThroughViewModelNameProperty()
        {
            documenttypename.Name = Teststring;
            Assert.Equal(Teststring, sut.Name);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenNamePropertySet()
        {
            Assert.PropertyChanged(sut, "Name", () => { sut.Name = Teststring; });
        }

    }
}
