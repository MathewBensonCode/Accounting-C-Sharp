using Moq;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Unity.ViewModelFactories;
using Unity;
using Unity.Resolution;
using Xunit;
using Accounts.Repositories;

namespace AccountsViewModelTests.Factories.Tests.UnityViewModelTests
{
    public abstract class UnityViewModelFactoryTests<T> where T : class
    {
        protected Mock<IRepository<T>> Repository { get; set; }
        protected Mock<IUnityContainer> Container { get; set; }

        protected Mock<IEntityViewModel<T>> EntityViewModel { get; set; }
        protected Mock<IEntityViewModel<T>> AnotherEntityViewModel { get; set; }
        protected Mock<T> Entity { get; set; }

        protected int Testint { get; set; }
        protected string TestName { get; set; }

        protected abstract UnityViewModelFactory<T> Sut { get; set; }

        public UnityViewModelFactoryTests()
        {
            Container = new Mock<IUnityContainer>();
            Repository = new Mock<IRepository<T>>();
            EntityViewModel = new Mock<IEntityViewModel<T>>();
            AnotherEntityViewModel = new Mock<IEntityViewModel<T>>();
            Entity = new Mock<T>();
            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<T>), null)).Returns(EntityViewModel.Object);
            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<T>), It.IsAny<string>())).Returns(AnotherEntityViewModel.Object);
            _ = Container.Setup(a => a.Resolve(typeof(IEntityViewModel<T>), null, new ResolverOverride[] { new ParameterOverride("entity", Entity.Object) })).Returns(EntityViewModel.Object);
            TestName = "TestName";
        }

        [Fact]
        public virtual void ShouldCreateViewModelFromResolveMethod()
        {
            var testsub = Sut.CreateViewModelForNewEntity();
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<T>), null), Times.Once);
        }

        [Fact]
        public virtual void ShouldCreateViewmodelFromResolveMethodWithNameParameter()
        {
            var testsub = Sut.CreateViewModelForNewEntity(TestName);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<T>), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public virtual void ShouldCreateViewModelFromExistingEntity()
        {
            var testsub = Sut.CreateViewModelFromEntity(Entity.Object);
            Container.Verify(a => a.Resolve(typeof(IEntityViewModel<T>), null, new ResolverOverride[] { new ParameterOverride("entity", Entity.Object) }), Times.Once);
        }

    }
}
