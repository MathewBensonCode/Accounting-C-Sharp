using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.Factories.Unity.ViewModelFactories;

namespace AccountsViewModelTests.Factories.Tests.UnityViewModelTests
{
    public class ImageUnityViewModelFactoryTests :
        UnityViewModelFactoryTests<DocumentImage>
    {
        public ImageUnityViewModelFactoryTests()
        {
            Sut = new UnityViewModelFactory<DocumentImage>(
                Container.Object
                );
        }
        protected override UnityViewModelFactory<DocumentImage> Sut { get; set; }
    }
}
