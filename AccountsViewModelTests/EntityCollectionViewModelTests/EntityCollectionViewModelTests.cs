using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.EntityCollectionViewModelTests
{
    public abstract class EntityCollectionViewModelTests<T> where T : class
    {
        private readonly Mock<IRepository<T>> repository;
        private readonly Mock<ICollectionListViewModelState<T>> listviewmodelstate;
        private readonly Mock<ICollectionCrudListViewStateFactory<T>> listviewstatefactory;
        private readonly EntityCollectionViewModel<T> sut;

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
