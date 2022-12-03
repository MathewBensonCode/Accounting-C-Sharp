using System.Collections.Generic;
using System.Collections.Specialized;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;

namespace AccountsViewModel.CollectionCrudViews
{
    public class EntityListCollectionViewModelState<T> :
        BindableBase,
        ICollectionListViewModelState<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly ICommandViewModelFactory<T> _commandFactory;
        private readonly IViewModelCollectionCreationService<T> _vmCreationService;
        private IEntityViewModel<T> _currentEntity;
        private int _currentpage;

        public EntityListCollectionViewModelState(
            IRepository<T> repository,
            ICollection<IEntityViewModel<T>> collection,
            ICommandViewModelFactory<T> commandfactory,
            ICollectionCrudAddViewStateFactory<T> addStateFactory,
            ICollectionCrudEditViewStateFactory<T> editStateFactory,
            IEntityCollectionViewModel<T> entityCollectionViewModel,
            IViewModelCollectionCreationService<T> vmCreationService
            )
        {
            EntityCollection = collection;
            _repository = repository;
            _commandFactory = commandfactory;
            ICollectionAddViewModelState<T> addViewState = addStateFactory.CreateEntityAddViewState(this, repository, entityCollectionViewModel);
            AddNewCommand = _commandFactory.CreateSelectAddViewCommand(addViewState, entityCollectionViewModel);
            ICollectionEditViewModelState<T> editViewState = editStateFactory.CreateEntityEditView(entityCollectionViewModel, repository, this);
            EditCurrentCommand = _commandFactory.CreateSelectEditViewCommand(editViewState, entityCollectionViewModel, this);
            DeleteCurrentCommand = _commandFactory.CreateDeleteCurrentCommand(this, repository);
            NextPageCommand = _commandFactory.CreateNextPageCommand(this, repository);
            PreviousPageCommand = _commandFactory.CreatePreviousPageCommand(this, repository);
            GoToBeginningCommand = _commandFactory.CreateGoToBeginningCommmand(this, repository);
            GoToEndCommand = _commandFactory.CreateGoToEndCommand(this, repository);
            _currentpage = 1;
            _vmCreationService = vmCreationService;
            _vmCreationService.CreateViewModelCollectionFromIEnumerable(EntityCollection, repository.GetDefault());

            _ = (DeleteCurrentCommand.Command as DelegateCommand).ObservesProperty(() => EntityViewModel);
            _ = (EditCurrentCommand.Command as DelegateCommand<string>).ObservesProperty(() => EntityViewModel);

            if (!(_repository is ISaveRepository childrepository))
            {
                var observablecollection = collection as INotifyCollectionChanged;
                observablecollection.CollectionChanged += AddToRepositoryWhenAddingToEntityCollection;
            }
        }

        private void AddToRepositoryWhenAddingToEntityCollection(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (IEntityViewModel<T> entity in e.NewItems)
                {
                    _repository.AddSingle(entity.Entity);
                }
            }
        }

        public virtual ICollection<IEntityViewModel<T>> EntityCollection { get; protected set; }

        public IEntityViewModel<T> EntityViewModel
        {
            get => _currentEntity;
            set => SetProperty(ref _currentEntity, value);
        }

        public ICommandViewModel AddNewCommand { get; protected set; }
        public ICommandViewModel EditCurrentCommand { get; protected set; }
        public ICommandViewModel DeleteCurrentCommand { get; protected set; }
        public ICommandViewModel NextPageCommand { get; protected set; }
        public ICommandViewModel PreviousPageCommand { get; protected set; }
        public ICommandViewModel GoToBeginningCommand { get; protected set; }
        public ICommandViewModel GoToEndCommand { get; protected set; }

        public int Count => _repository.Count;

        public int CurrentPage
        {
            get => _currentpage;
            set
            {
                if (Nextpagevalid(value))
                {
                    _vmCreationService.CreateViewModelCollectionFromIEnumerable(EntityCollection, _repository.GetPageCollection(value));
                    _currentpage = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool Nextpagevalid(int newvalue)
        {
            return (newvalue > 0) && (Count - (newvalue * _repository.GetPageSize()) > 0);
        }

    }
}
