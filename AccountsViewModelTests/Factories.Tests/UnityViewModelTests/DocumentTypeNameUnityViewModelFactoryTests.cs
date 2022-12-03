using AccountLib.Interfaces;
using AccountLib.Model;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Factories.Unity.ViewModelFactories;
using Moq;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityViewModelTests
{
    public class DocumentTypeNameUnityViewModelFactoryTests
        : UnityViewModelFactoryTests<DocumentTypeName>
    {
        private readonly Mock<IBusinessEntitySourceDocumentType> businessEntitySourceDocumentType;
        private readonly DocumentTypeNameUnityViewModelFactory sut;

        protected override UnityViewModelFactory<DocumentTypeName> Sut { get; set; }

        public DocumentTypeNameUnityViewModelFactoryTests()
        {
            businessEntitySourceDocumentType = new Mock<IBusinessEntitySourceDocumentType>();
            sut = new DocumentTypeNameUnityViewModelFactory(
                Repository.Object,
                Container.Object
                );
            Sut = sut;
        }

        [Fact]
        public void ShouldImplementIDocumentTypeNameViewModelFactory()
        {
            Assert.IsAssignableFrom<IDocumentTypeNameViewModelFactory>(sut);
        }

        [Fact]
        public void ShouldCreateDocumentTypeNameViewModelFromBusinessEntitySourceDocumentType()
        {
            businessEntitySourceDocumentType
                .Setup(a => a.DocumentTypeNameId)
                .Returns(It.IsAny<int>());
            Repository
                .Setup(a => a.Find(businessEntitySourceDocumentType.Object.DocumentTypeNameId))
                .Returns(Entity.Object);
            sut.GetDocumentTypeNameViewModelForBusinessEntitySourceDocumentType(businessEntitySourceDocumentType.Object);

            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<DocumentTypeName>), null,
                new ResolverOverride[] {
                    new ParameterOverride("entity", Entity.Object) }));
        }
    }
}
