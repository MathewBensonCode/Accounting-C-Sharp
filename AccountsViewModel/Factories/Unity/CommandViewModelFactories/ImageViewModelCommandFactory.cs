using System.Windows.Input;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.CommandViewModelFactories
{
    public class UnityImageViewModelCommandFactory :
        IImageViewModelCommandFactory
    {
        IUnityContainer _container;

        public UnityImageViewModelCommandFactory(IUnityContainer container)
        {
            _container = container;
        }

        public ICommandViewModel CreateGetImageFromFileCommand(IDocumentImageViewModel imageViewModel)
        {
            var command = _container.Resolve(typeof(ICommand), "GetImageFromFileCommand",
                    new ResolverOverride[]
                    {
                new ParameterOverride("imageViewModel", imageViewModel)
                    }
                    );

            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null, new ResolverOverride[]
                    {
                new ParameterOverride("command", command)
                    }
                    );

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateGetTextFromImageCommand(IDocumentImageViewModel imageViewModel)
        {
            var command = _container.Resolve(typeof(ICommand), "GetTextFromImageCommand",
                    new ResolverOverride[]
                    {
                new ParameterOverride("imageViewModel", imageViewModel)
                    }
                    );

            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null, new ResolverOverride[]
                    {
                new ParameterOverride("command", command)
                    }
                    );

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateScanImageCommand(IDocumentImageViewModel imageViewModel)
        {
            var command = _container.Resolve(typeof(ICommand), "ScanImageCommand",
                    new ResolverOverride[]
                    {
                new ParameterOverride("imageViewModel", imageViewModel)
                    }
                    );

            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null, new ResolverOverride[]
                    {
                new ParameterOverride("command", command)
                    }
                    );

            return commandviewmodel as ICommandViewModel;
        }
    }
}
