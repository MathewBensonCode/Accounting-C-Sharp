using Moq;
using System.Text.RegularExpressions;
using AccountsViewModel.Factories.Interfaces.RegexFactories;
using AccountsViewModel.Factories.Unity;
using Unity;
using Unity.Resolution;
using Xunit;

namespace AccountsViewModelTests.Factories.Tests.RegexFactoryTests
{
    public class RegexFactoryTests
    {
        private readonly RegexFactory sut;
        private readonly Mock<IUnityContainer> container;

        public RegexFactoryTests()
        {
            container = new Mock<IUnityContainer>();
            sut = new RegexFactory(container.Object);
        }

        [Fact]
        public void ShouldImplementIRegexFactory()
        {
            Assert.IsAssignableFrom<IRegexFactory>(sut);
        }

        [Fact]
        public void ShouldCreateRegexUsingUnity()
        {
            var teststring = "teststring";
            sut.CreateRegex(teststring);
            container.Verify(a => a.Resolve(typeof(Regex), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("pattern", teststring)
                }
                ));
        }
    }
}
