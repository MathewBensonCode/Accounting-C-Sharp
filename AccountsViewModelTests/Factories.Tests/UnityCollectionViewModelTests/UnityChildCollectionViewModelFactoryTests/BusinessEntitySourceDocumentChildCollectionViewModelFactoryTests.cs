using AccountLib.Model.Source_Documents;
using AccountLib.Interfaces;
using AccountsRepositoriesCore.Interfaces;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using Xunit;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityCollectionViewModelTests.UnityChildCollectionViewModelFactoryTests
{
    public class BusinessEntitySourceDocumentTypeChildCollectionViewModelFactoryTests
    {
        Mock<IBusinessEntitySourceDocumentType> businessEntitySourceDocumentType;
        Mock<ICollection<BusinessEntitySourceDocumentType>> businessEntitySourceDocumentTypeCollection;
        Mock<ICollectionViewModelFactory<BusinessEntitySourceDocumentType>> businessEntitySourceDocumentTypeCollectionViewModelFactory;
        Mock<IBusinessEntitySourceDocumentTypeRepository> repository;
        Mock<IBusinessEntity> businessEntity;
        BusinessEntitySourceDocumentTypeChildCollectionViewModelFactory sut;

        public BusinessEntitySourceDocumentTypeChildCollectionViewModelFactoryTests()
        {
            businessEntitySourceDocumentType = new Mock<IBusinessEntitySourceDocumentType>();
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
