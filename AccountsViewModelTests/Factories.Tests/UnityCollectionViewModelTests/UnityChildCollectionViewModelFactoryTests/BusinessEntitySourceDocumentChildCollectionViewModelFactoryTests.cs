using System.Collections.Generic;
using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionViewModelTests.UnityChildCollectionViewModelFactoryTests
{
    public class BusinessEntitySourceDocumentTypeChildCollectionViewModelFactoryTests
    {
        private readonly Mock<ICollection<BusinessEntitySourceDocumentType>> businessEntitySourceDocumentTypeCollection;
        private readonly Mock<ICollectionViewModelFactory<BusinessEntitySourceDocumentType>> businessEntitySourceDocumentTypeCollectionViewModelFactory;
        private readonly Mock<IBusinessEntitySourceDocumentTypeRepository> repository;
        private readonly Mock<IBusinessEntity> businessEntity;
        private readonly BusinessEntitySourceDocumentTypeChildCollectionViewModelFactory sut;

        public BusinessEntitySourceDocumentTypeChildCollectionViewModelFactoryTests()
        {
            businessEntitySourceDocumentTypeCollection = new Mock<ICollection<BusinessEntitySourceDocumentType>>();
            businessEntitySourceDocumentTypeCollectionViewModelFactory = new Mock<ICollectionViewModelFactory<BusinessEntitySourceDocumentType>>();
            businessEntity = new Mock<IBusinessEntity>();
            repository = new Mock<IBusinessEntitySourceDocumentTypeRepository>();
            sut = new BusinessEntitySourceDocumentTypeChildCollectionViewModelFactory(
                repository.Object,
                businessEntitySourceDocumentTypeCollectionViewModelFactory.Object
                );
        }

        [Fact]
        public void ShouldImplementIBusinessEntitySourceDocumentTypeChildCollectionViewModelFactoryInterface()
        {
            Assert.IsAssignableFrom<IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory>(sut);
        }

        [Fact]
        public void ShouldCreateChildCollectionViewModelForBusinessEntityWhenBusinessEntitySourceDocumentTypeIsNull()
        {
            businessEntity.SetupProperty(a => a.BusinessEntitySourceDocumentTypes);
            businessEntity.Object.BusinessEntitySourceDocumentTypes = null;
            repository
                .Setup(a => a.GetBusinessEntitySourceDocumentTypesForBusinessEntity(businessEntity.Object))
                .Returns(businessEntitySourceDocumentTypeCollection.Object);
            sut.GetBusinessEntitySourceDocumentTypeCollectionViewModelForBusinessEntity(businessEntity.Object);
            businessEntitySourceDocumentTypeCollectionViewModelFactory
                .Verify(a => a.CreateNewCollectionViewModel(businessEntitySourceDocumentTypeCollection.Object), Times.Once);
        }

        [Fact]
        public void ShouldCreateChildCollectionViewModelForBusinessEntityWhenBusinessEntitySourceDocumentTypeIsNotNull()
        {
            businessEntity.SetupProperty(a => a.BusinessEntitySourceDocumentTypes);
            businessEntity.Object.BusinessEntitySourceDocumentTypes = businessEntitySourceDocumentTypeCollection.Object;

            sut.GetBusinessEntitySourceDocumentTypeCollectionViewModelForBusinessEntity(businessEntity.Object);
            businessEntitySourceDocumentTypeCollectionViewModelFactory
                .Verify(a => a.CreateNewCollectionViewModel(businessEntitySourceDocumentTypeCollection.Object), Times.Once);
        }
    }
}
