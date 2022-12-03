using Accounts.Repositories;
using AccountLib.Model;
using AccountLib.Model.Source_Documents;
using System.ComponentModel;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public class BusinessEntitySourceDocumentTypeAddCollectionViewModelState :
        AddNewEntityToCollectionViewModelState<BusinessEntitySourceDocumentType>, ICollectionAddViewModelState<BusinessEntitySourceDocumentType>
    {
        public BusinessEntitySourceDocumentTypeAddCollectionViewModelState(
            ICollectionListViewModelState<BusinessEntitySourceDocumentType> listViewModelState,
            IRepository<BusinessEntitySourceDocumentType> repository,
            IEntityCollectionViewModel<BusinessEntitySourceDocumentType> collectionViewModel,
            ICollectionViewModelFactory<DocumentTypeName> documentTypeNameFactory,
            ICommandViewModelFactory<BusinessEntitySourceDocumentType> commandfactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
            DocumentTypeNames = documentTypeNameFactory.CreateNewCollectionViewModel(null);
            (DocumentTypeNames.CollectionViewState as INotifyPropertyChanged).PropertyChanged += DocumentTypeNameSelected;
        }

        public IEntityCollectionViewModel<DocumentTypeName> DocumentTypeNames { get; private set; }

        private void DocumentTypeNameSelected(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "DocumentTypeNameId")
            {
                (EntityViewModel as IBusinessEntitySourceDocumentTypeViewModel).DocumentTypeNameId = (DocumentTypeNames.CollectionViewState as ICollectionListViewModelState<DocumentTypeName>).EntityViewModel.Id;
            }
        }
    }
}
