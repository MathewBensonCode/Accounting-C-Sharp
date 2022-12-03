using AccountLib.Model.SourceDocuments;
using Accounts.Repositories;
using AutoFixture.Xunit2;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using AccountsViewModel.Xunit.Tests.autofixtureattributes;
using Unity;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityCollectionViewModelTests.UnityChildCollectionViewModelFactoryTests
{
    public class SourceDocumentChildCollectionViewModelFactoryTests
    {
        [Theory, AutoCatalogData]
        public void ShouldBeOfTypeISourceDocumentChildCollectionViewModelFactory(
            
            SourceDocumentChildCollectionViewModelFactory sut
            )
        {
            Assert.IsAssignableFrom<ISourceDocumentChildCollectionViewModelFactory>(sut);
        }

        //[Theory, AutoCatalogData]
        //public void ShouldCreateEntityCollectionViewModelOfSourceDocumentsForABusinessEntity(
        //    [Frozen]Mock<ISourceDocumentRepository> sourcedocumentrepository,
        //    [Frozen]Mock<ICollection<SourceDocument>> sourcedocumentcollection,
        //    [Frozen]Mock<IBusinessEntity> businessentity,
        //    Mock<IEntityCollectionViewModel<SourceDocument>> sourcedocumentchildcollectionvm,
        //    [Frozen]Mock<ICollectionViewModelFactory<SourceDocument>> collectionviewmodelfactory,
        //    SourceDocumentChildCollectionViewModelFactory sut
        //    )
        //{
        //    sourcedocumentrepository.Setup(a => a.GetSourceDocumentsForBusinessEntity(businessentity.Object))
        //        .Returns(sourcedocumentcollection.Object);
        //    collectionviewmodelfactory.Setup(a => a.CreateNewCollectionViewModel(sourcedocumentcollection.Object))
        //        .Returns(sourcedocumentchildcollectionvm.Object);

        //    Assert.Equal(sourcedocumentchildcollectionvm.Object, sut.CreateSourceDocumentCollectionViewModelFromBusinessEntity(businessentity.Object));
        //}

       


    }
}
