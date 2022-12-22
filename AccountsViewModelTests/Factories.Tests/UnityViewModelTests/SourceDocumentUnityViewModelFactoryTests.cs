using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Interfaces.Images;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Unity.ViewModelFactories;
using Moq;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityViewModelTests
{
    public class SourceDocumentUnityViewModelFactoryTests :
        UnityViewModelFactoryTests<SourceDocument>
    {
        private readonly Mock<IDocumentImage> image;
        private readonly Mock<ITransaction> transaction;
        private readonly SourceDocumentUnityViewModelFactory sut;
        private readonly int testint = 4;

        public SourceDocumentUnityViewModelFactoryTests()
        {
            image = new Mock<IDocumentImage>();
            transaction = new Mock<ITransaction>();

            _ = image.Setup(a => a.SourceDocumentId).Returns(testint);
            _ = Repository.Setup(a => a.Find(image.Object.SourceDocumentId)).Returns(Entity.Object);

            _ = transaction.Setup(a => a.SourceDocumentId);
            _ = Repository.Setup(a => a.Find(transaction.Object.SourceDocumentId)).Returns(Entity.Object);

            sut = new SourceDocumentUnityViewModelFactory(
                Repository.Object,
                Container.Object
                );

            Sut = sut;

        }

        protected override UnityViewModelFactory<SourceDocument> Sut { get; set; }

        [Fact]
        public void ShouldCreateSourceDocumentViewModelFromImage()
        {
            _ = sut.CreateSourceDocumentViewModelForImage(image.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<SourceDocument>), null,
                new ResolverOverride[] { new ParameterOverride("entity", Entity.Object) }));
        }

        [Fact]
        public void ShouldCreateSourceDocumentViewModelFromTransaction()
        {
            _ = sut.CreateSourceDocumentViewModelForTransaction(transaction.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<SourceDocument>), null,
              new ResolverOverride[] { new ParameterOverride("entity", Entity.Object) }));
        }
    }
}
