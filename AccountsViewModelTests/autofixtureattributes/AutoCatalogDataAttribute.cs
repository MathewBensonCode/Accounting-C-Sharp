using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace AccountsViewModelTests.AutofixtureAttributes
{
    public class AutoCatalogDataAttribute : AutoDataAttribute
    {
        public AutoCatalogDataAttribute() : base(() => new Fixture()
        .Customize(new AutoMoqCustomization())

        )
        {
        }
    }
}
