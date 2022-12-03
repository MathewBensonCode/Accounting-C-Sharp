using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountLib.Model.Source_Documents;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using System.Linq;
using AccountsModelCore.Classes.DocumentImages;

namespace AccountsViewModel.CollectionCrudViews
{
    public abstract class SourceDocumentAddEditCollectionViewModelState
        : AddEditEntityCollectionViewModelState<SourceDocument>, ISourceDocumentCollectionAddEditViewModelState
    {
        protected ISourceDocumentCollectionAddEditViewModelStateCommandFactory _sourceDocumentCollectionAddEditViewModelStateCommandFactory;
        protected ICommandViewModel _readDataFromImageTextCommand;
        protected readonly IEntityCollectionViewModel<BusinessEntity> _businessEntityCollectionViewModel;
        private string _sourceDocumentText;
        private bool _imagePanelVisible;
        private bool _businessEntityPanelVisible;
        private bool _sourceDocumentTextPanelVisible;
        private bool _dateAndTransactionsPanelVisible;
        private ICollection<IEntityViewModel<DocumentImage>> _imageEntityCollection;
        private IEntityCollectionViewModel<DocumentImage> _currentEntityImageCollectionViewModel;
        private IEntityCollectionViewModel<Transaction> _currentEntityTransactionCollectionViewModel;
        private ICollectionListViewModelState<BusinessEntitySourceDocumentType> _currentBusinessEntitySourceDocumentTypeCollectionListView;

        public SourceDocumentAddEditCollectionViewModelState(
            ICollectionListViewModelState<SourceDocument> listViewModelState,
            IRepository<SourceDocument> repository,
            IEntityCollectionViewModel<SourceDocument> collectionViewModel,
            ICollectionViewModelFactory<BusinessEntity> businessEntityCollectionViewModelFactory,
            ISourceDocumentCollectionAddEditViewModelStateCommandFactory sourceDocumentViewModelCommandFactory,
            ICommandViewModelFactory<SourceDocument> commandfactory) :
            base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
            PropertyChanged += ChangePanelVisibilityWhenSourceDocumentTextChanges;
            PropertyChanged += UpdateImageCollectionViewModelWhenNewEntityChanges;
            PropertyChanged += UpdateTransactionCollectionViewModelWhenNewEntityChanges;
            _businessEntityCollectionViewModel = businessEntityCollectionViewModelFactory.CreateNewCollectionViewModel(null);
            BusinessEntityCollectionViewModel.PropertyChanged += UpdatePanelVisibilityWhenCollectionViewModelViewStateChanges;
            (BusinessEntityCollectionViewModel.CollectionViewState as INotifyPropertyChanged).PropertyChanged += UpdateCurrentSelectedBusinessEntityWhenNewBusinessEntitySelected;
            _sourceDocumentCollectionAddEditViewModelStateCommandFactory = sourceDocumentViewModelCommandFactory;
            UpdateImagePanelVisibility();
            UpdateSourceDocumentTextPanelVisibility();
            UpdateBusinessEntityPanelVisibility();
            UpdateDateAndTransactionsPanelVisibility();
        }

        private void UpdateCurrentSelectedBusinessEntityWhenNewBusinessEntitySelected(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "EntityViewModel")
            {
                if (_currentBusinessEntitySourceDocumentTypeCollectionListView != null)
                {
                    _currentBusinessEntitySourceDocumentTypeCollectionListView.PropertyChanged -= UpdateBusinessEntitySourceDocumentTypeIdOnEntityWhenTheSourceDocumentTypeOnTheCurrentBusinessEntityChanges;
                }

                var businessentitylistviewstate = (ICollectionListViewModelState<BusinessEntity>)BusinessEntityCollectionViewModel.CollectionViewState;
                var currentbusinessentityviewmodel = (IBusinessEntityViewModel)businessentitylistviewstate.EntityViewModel;
                _currentBusinessEntitySourceDocumentTypeCollectionListView = (ICollectionListViewModelState<BusinessEntitySourceDocumentType>)currentbusinessentityviewmodel.BusinessEntitySourceDocumentTypes.CollectionViewState;
                _currentBusinessEntitySourceDocumentTypeCollectionListView.PropertyChanged += UpdateBusinessEntitySourceDocumentTypeIdOnEntityWhenTheSourceDocumentTypeOnTheCurrentBusinessEntityChanges;
            }
        }

        private void UpdateBusinessEntitySourceDocumentTypeIdOnEntityWhenTheSourceDocumentTypeOnTheCurrentBusinessEntityChanges(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "EntityViewModel")
            {
                (EntityViewModel as ISourceDocumentViewModel).BusinessEntitySourceDocumentTypeId = _currentBusinessEntitySourceDocumentTypeCollectionListView.EntityViewModel.Id;
            }
        }

        private void UpdateImagePanelVisibility()
        {
            ImagePanelVisible = !(_businessEntityCollectionViewModel.CollectionViewState is ICollectionAddEditViewModelState<BusinessEntity>)
           && (_currentEntityImageCollectionViewModel == null || !(_currentEntityTransactionCollectionViewModel.CollectionViewState is ICollectionAddEditViewModelState<Transaction>));
        }

        private void UpdateSourceDocumentTextPanelVisibility()
        {
            SourceDocumentTextPanelVisible = (!string.IsNullOrEmpty(SourceDocumentText))
        && (!(_currentEntityImageCollectionViewModel.CollectionViewState is ICollectionAddEditViewModelState<DocumentImage>));
        }

        private void UpdateBusinessEntityPanelVisibility()
        {
            BusinessEntityPanelVisible = !string.IsNullOrEmpty(SourceDocumentText)
        && (_currentEntityImageCollectionViewModel == null || !(_currentEntityImageCollectionViewModel.CollectionViewState is ICollectionAddEditViewModelState<DocumentImage>))
    && (_currentEntityTransactionCollectionViewModel == null || !(_currentEntityTransactionCollectionViewModel.CollectionViewState is ICollectionAddEditViewModelState<Transaction>));
        }

        private void UpdateDateAndTransactionsPanelVisibility()
        {
            DateAndTransactionsPanelVisible = (!string.IsNullOrEmpty(SourceDocumentText))
                && (!(_currentEntityImageCollectionViewModel.CollectionViewState is ICollectionAddEditViewModelState<DocumentImage>))
                && (!(BusinessEntityCollectionViewModel.CollectionViewState is ICollectionAddEditViewModelState<BusinessEntity>));
        }

        private void UpdateImageCollectionViewModelWhenNewEntityChanges(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "EntityViewModel" && sender == this)
            {
                if (_currentEntityImageCollectionViewModel != null)
                {
                    _currentEntityImageCollectionViewModel.PropertyChanged -= UpdatePanelVisibilityWhenCollectionViewModelViewStateChanges;
                }

                _currentEntityImageCollectionViewModel = (EntityViewModel as ISourceDocumentViewModel).ImageCollectionViewModel;
                _imageEntityCollection = (_currentEntityImageCollectionViewModel.CollectionViewState as ICollectionListViewModelState<DocumentImage>).EntityCollection;
                (_imageEntityCollection as INotifyCollectionChanged).CollectionChanged += AddRemovePropertyChangedHandlerforImageCollection;
                SourceDocumentText = GetCombinedSourceDocumentImageString(_imageEntityCollection);
                _currentEntityImageCollectionViewModel.PropertyChanged += UpdatePanelVisibilityWhenCollectionViewModelViewStateChanges;
            }
        }

        private void UpdateTransactionCollectionViewModelWhenNewEntityChanges(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "EntityViewModel" && sender == this)
            {
                if (_currentEntityTransactionCollectionViewModel != null)
                {
                    _currentEntityTransactionCollectionViewModel.PropertyChanged -= UpdatePanelVisibilityWhenCollectionViewModelViewStateChanges;
                }

                _currentEntityTransactionCollectionViewModel = (EntityViewModel as ISourceDocumentViewModel).TransactionCollectionViewModel;
                _currentEntityTransactionCollectionViewModel.PropertyChanged += UpdatePanelVisibilityWhenCollectionViewModelViewStateChanges;
            }
        }

        private void UpdatePanelVisibilityWhenCollectionViewModelViewStateChanges(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "CollectionViewState")
            {
                UpdateImagePanelVisibility();
                UpdateSourceDocumentTextPanelVisibility();
                UpdateBusinessEntityPanelVisibility();
                UpdateDateAndTransactionsPanelVisibility();
            }
        }

        private void ChangePanelVisibilityWhenSourceDocumentTextChanges(object sender, PropertyChangedEventArgs args)
        {
            if ((sender == this) && (args.PropertyName == "SourceDocumentText"))
            {
                UpdateSourceDocumentTextPanelVisibility();
                UpdateBusinessEntityPanelVisibility();
                UpdateDateAndTransactionsPanelVisibility();
            }
        }

        public IEntityCollectionViewModel<BusinessEntity> BusinessEntityCollectionViewModel => _businessEntityCollectionViewModel;

        protected void CreateReadDataFromImageTextCommand()
        {
            _readDataFromImageTextCommand = _sourceDocumentCollectionAddEditViewModelStateCommandFactory.CreateReadFromImageTextCommand(this);
        }

        public ICommandViewModel ReadTextFromImageCommand
        {
            get
            {
                if (_readDataFromImageTextCommand == null)
                {
                    CreateReadDataFromImageTextCommand();
                }

                return _readDataFromImageTextCommand;
            }
        }

        public string SourceDocumentText
        {
            get => _sourceDocumentText;
            protected set => SetProperty(ref _sourceDocumentText, value);
        }

        public bool ImagePanelVisible
        {
            get => _imagePanelVisible;

            protected set => SetProperty(ref _imagePanelVisible, value);
        }

        public bool BusinessEntityPanelVisible
        {
            get => _businessEntityPanelVisible;

            protected set => SetProperty(ref _businessEntityPanelVisible, value);
        }

        public bool SourceDocumentTextPanelVisible
        {
            get => _sourceDocumentTextPanelVisible;

            protected set => SetProperty(ref _sourceDocumentTextPanelVisible, value);
        }

        public bool DateAndTransactionsPanelVisible
        {
            get => _dateAndTransactionsPanelVisible;

            protected set => SetProperty(ref _dateAndTransactionsPanelVisible, value);
        }

        private void BusinessEntitySourceDocumentTypeSelected(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "BusinessEntitySourceDocumentTypeId")
            {
                (EntityViewModel as ISourceDocumentViewModel).BusinessEntitySourceDocumentTypeId = (BusinessEntityCollectionViewModel.CollectionViewState as ICollectionListViewModelState<BusinessEntity>).EntityViewModel.Id;
            }
        }

        private string GetCombinedSourceDocumentImageString(ICollection<IEntityViewModel<DocumentImage>> imageviewmodels)
        {
            var sourceDocumentText = string.Empty;

            foreach (IDocumentImageViewModel imgvm in imageviewmodels.Cast<IDocumentImageViewModel>())
            {
                sourceDocumentText += imgvm.SourceDocumentText + "\n";
            }

            return sourceDocumentText;
        }

        private void AddRemovePropertyChangedHandlerforImageCollection(object sender, NotifyCollectionChangedEventArgs args)
        {
            if ((args.NewItems != null) && (args.NewItems.Count > 0))
            {
                AddPropertyChangedHandlers(args.NewItems);
            }

            if ((args.OldItems != null) && (args.OldItems.Count > 0))
            {
                RemovePropertyChangedHandlers(args.OldItems);
            }

            SourceDocumentText = GetCombinedSourceDocumentImageString(_imageEntityCollection);

        }

        private void AddPropertyChangedHandlers(IList collection)
        {
            foreach (object obj in collection)
            {
                if (obj is INotifyPropertyChanged PropertyChanged)
                {
                    PropertyChanged.PropertyChanged += ReloadSourceDocumentTextWhenImageTextChanges;
                }
            }
        }

        private void RemovePropertyChangedHandlers(IList collection)
        {
            foreach (object obj in collection)
            {
                if (obj is INotifyPropertyChanged PropertyChanged)
                {
                    PropertyChanged.PropertyChanged -= ReloadSourceDocumentTextWhenImageTextChanges;
                }
            }
        }

        private void ReloadSourceDocumentTextWhenImageTextChanges(object sender, PropertyChangedEventArgs args)
        {
            SourceDocumentText = GetCombinedSourceDocumentImageString(_imageEntityCollection);
        }
    }
}
