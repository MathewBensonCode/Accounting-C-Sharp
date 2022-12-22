using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Classes;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Factories.Unity.ViewModelFactories;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityViewModelTests
{
    public class BusinessEntitySourceDocumentTypeUnityViewModelFactoryTests :
        UnityViewModelFactoryTests<BusinessEntitySourceDocumentType>
    {

        protected override UnityViewModelFactory<BusinessEntitySourceDocumentType> Sut { get; set; }
        private readonly SourceDocument sourceDocument;

        public BusinessEntitySourceDocumentTypeUnityViewModelFactoryTests()
        {
            sourceDocument = new SourceDocument();
            Sut = new BusinessEntitySourceDocumentTypeUnityViewModelFactory(
                Repository.Object,
                Container.Object
                );
        }

        [Fact]
        public void ShouldImplementIBusinessEntitySourceDocumentTypeViewModelFactory()
        {
            _ = Assert.IsAssignableFrom<IBusinessEntitySourceDocumentTypeViewModelFactory>(Sut);
        }

        [Fact]
        public void ShouldCreateBusinessEntitySourceDocumentTypeViewModelForSourceDocument()
        {
            _ = sourceDocument.BusinessEntitySourceDocumentTypeId = 5;
            _ = Repository.Setup(a => a.Find(sourceDocument.BusinessEntitySourceDocumentTypeId))
                .Returns(Entity.Object);
            _ = ((BusinessEntitySourceDocumentTypeUnityViewModelFactory)Sut).GetBusinessEntitySourceDocumentTypeViewModelForSourceDocument(sourceDocument);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<BusinessEntitySourceDocumentType>), null,
                new ResolverOverride[] {
                    new ParameterOverride("entity", Entity.Object) }));
        }
    }
}
