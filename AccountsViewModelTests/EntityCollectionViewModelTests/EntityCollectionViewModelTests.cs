using Accounts.Repositories;
using Moq;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.EntityCollectionViewModelTests
{
    public abstract class EntityCollectionViewModelTests<T> where T : class
    {
        Mock<IRepository<T>> repository;
        Mock<ICollectionListViewModelState<T>> listviewmodelstate;
        Mock<ICollectionCrudListViewStateFactory<T>> listviewstatefactory;
        EntityCollectionViewModel<T> sut;

        public EntityCollectionViewModelTests()
        {
            repository = new Mock<IRepository<T>>();
            listviewmodelstate = new Mock<ICollectionListViewModelState<T>>();
            listviewstatefactory = new Mock<ICollectionCrudListViewStateFactory<T>>();

            listviewstatefactory.Setup(a => a.CreateEntityListView(It.IsAny<IEntityCollectionViewModel<T>>(), repository.Object))
                .Returns(listviewmodelstate.Object);

            sut = new EntityCollectionViewModel<T>(
                repository.Object,
                listviewstatefactory.Object
                );
        }

        [Fact]
        public void ShouldImplementIEntityCollectionViewModel()
        {
            Assert.IsAssignableFrom<IEntityCollectionViewModel<T>>(sut);
        }

        [Fact]
        public void ShouldContainPropertyWithCollectionViewModelState()
        {
            Assert.IsAssignableFrom<ICollectionViewModelState<T>>(sut.CollectionViewState);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenCollectionViewStatePropertyChanged()
        {
            var newcollectionviewmodelstate = new Mock<ICollectionViewModelState<T>>();
            Assert.PropertyChanged(sut, "CollectionViewState", () => { sut.CollectionViewState = newcollectionviewmodelstate.Object; });
        }

        [Fact]
        public void ShouldUseListViewStateFactoryToCreateTheListCollectionViewModelState()
        {
            Assert.Same(listviewmodelstate.Object, sut.CollectionViewState);
        }

    }
}
