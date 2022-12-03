using AccountsViewModel.EntityViewModels;
using AccountLib.Interfaces;
using Xunit;
using Moq;
using System.ComponentModel;
using System.Collections.Generic;
using AccountsViewModel.EntityViewModels.Classes;

namespace AccountsViewModelTests.EntityViewModel.Tests
{
    public abstract class EntityViewModelTests<T>
        where T : class, IDbModel
    {
        protected Mock<IDictionary<string, List<string>>> ErrorCollection { get; set; }
        protected abstract T Entity { get; set; }
        protected abstract EntityViewModel<T> Sut { get; set; }
        public EntityViewModelTests()
        {
            ErrorCollection = new Mock<IDictionary<string, List<string>>>();
        }

        [Fact]
        public void EntityShouldNotBeNull()
        {
            _ = Assert.IsAssignableFrom<T>(Sut.Entity);
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChangedInterface()
        {
            _ = Assert.IsAssignableFrom<INotifyPropertyChanged>(Sut);
        }

        [Fact]
        public void ShouldImplementIEntityViewModel()
        {
            _ = Assert.IsAssignableFrom<IEntityViewModel<T>>(Sut);
        }

        [Fact]
        public void ShouldHaveIdPropertyThatReturnsTheValueOfTheUnderlyingEntity()
        {
            Entity.Id = 4;
            Assert.Equal(4, Sut.Id);
        }

        [Fact]
        public void ShouldImplementINotifyDataErrorInfo()
        {
            _ = Assert.IsAssignableFrom<INotifyDataErrorInfo>(Sut);
        }

        [Fact]
        public void ShouldReturnFalseIfErrorsCollectionDoesNotContainErrors()
        {
            _ = ErrorCollection.Setup(a => a.Values.Count).Returns(0);
            var Sut = new EntityViewModel<T>(It.IsAny<T>(), ErrorCollection.Object);
            Assert.False(Sut.HasErrors);
        }

        [Fact]
        public void ShouldReturnTrueIfErrorsCollectionContainsErrors()
        {
            _ = ErrorCollection.Setup(a => a.Values.Count).Returns(2);
            var Sut = new EntityViewModel<T>(It.IsAny<T>(), ErrorCollection.Object);
            Assert.True(Sut.HasErrors);
        }

        public void ShouldReturnCollectionOfErrorsFromUnderlyingDictionaryForPropertyName()
        {
            string propertyname = "testproperty";
            _ = Sut.GetErrors(propertyname);
        }

        [Fact]
        public void ShouldHavePropertyShowingIfAnyDataHasChanged()
        {
            Assert.False(Sut.HasChanged);
        }
    }
}
