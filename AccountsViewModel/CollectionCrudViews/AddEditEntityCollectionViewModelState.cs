using System.ComponentModel;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using Prism.Commands;
using Prism.Mvvm;

namespace AccountsViewModel.CollectionCrudViews
{
    public abstract class AddEditEntityCollectionViewModelState<T>
    : BindableBase, ICollectionAddEditViewModelState<T>
    where T : class
    {
        protected ICommandViewModelFactory<T> CommandFactory { get; set; }
        protected IEntityCollectionViewModel<T> CollectionViewModel { get; set; }
        protected ICollectionListViewModelState<T> ListViewModelState { get; set; }
        protected IRepository<T> Repository { get; set; }

        public AddEditEntityCollectionViewModelState(
        ICollectionListViewModelState<T> listViewModelState,
        IRepository<T> repository,
        IEntityCollectionViewModel<T> collectionViewModel,
        ICommandViewModelFactory<T> commandfactory
        )
        {
            CommandFactory = commandfactory;
            Repository = repository;
            ListViewModelState = listViewModelState;
            CollectionViewModel = collectionViewModel;
            CancelCommand = commandfactory.CreateCancelAddNewEditCommand(listViewModelState, collectionViewModel);
            PropertyChanged += UpdateCommands;
        }

        private IEntityViewModel<T> _entityviewmodel;
        public IEntityViewModel<T> EntityViewModel
        {
            get => _entityviewmodel;
            set
            {
                if (_entityviewmodel != value)
                {
                    SaveCommand = null;
                    _entityviewmodel = value;

                    RaisePropertyChanged();
                }
            }
        }

        public ICommandViewModel SaveCommand { get; protected set; }
        public ICommandViewModel CancelCommand { get; protected set; }

        private void UpdateCommands(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "EntityViewModel")
            {
                CreateSaveCommand();
                _ = (SaveCommand.Command as DelegateCommand).ObservesProperty(() => EntityViewModel.HasChanged).
                 ObservesProperty(() => EntityViewModel.HasErrors);
            }
        }

        protected abstract void CreateSaveCommand();

    }
}
