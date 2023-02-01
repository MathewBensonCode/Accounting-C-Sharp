using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.CommandViewModelFactories
{
    public class UnitySourceDocumentCollectionAddEditViewModelStateCommandFactory :
        ISourceDocumentCollectionAddEditViewModelStateCommandFactory
    {
        private readonly IUnityContainer _container;

        public UnitySourceDocumentCollectionAddEditViewModelStateCommandFactory(IUnityContainer container)
        {
            _container = container;
        }

        public ICommandViewModel CreateReadFromImageTextCommand(ISourceDocumentCollectionAddEditViewModelState sourceDocumentCollectionAddEditViewModelState)
        {
            var command = _container.Resolve(typeof(ICommand), "ReadDataFromImageTextAddEditViewCommand",
                    new ResolverOverride[]
                    {
                new ParameterOverride("sourceDocumentCollectionAddEditViewModelState", sourceDocumentCollectionAddEditViewModelState)
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
