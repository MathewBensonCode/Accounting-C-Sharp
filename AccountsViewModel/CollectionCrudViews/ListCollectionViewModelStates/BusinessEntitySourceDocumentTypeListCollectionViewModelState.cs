using System.Collections.Generic;
using AccountsModelCore.Classes;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.ListCollectionViewModelStates
{
    public class BusinessEntitySourceDocumentTypeListCollectionViewModelState :
        EntityListCollectionViewModelState<BusinessEntitySourceDocumentType>
    {
        public BusinessEntitySourceDocumentTypeListCollectionViewModelState(
            IRepository<BusinessEntitySourceDocumentType> repository,
            ICollection<IEntityViewModel<BusinessEntitySourceDocumentType>> collection,
            ICommandViewModelFactory<BusinessEntitySourceDocumentType> commandfactory,
            ICollectionCrudAddViewStateFactory<BusinessEntitySourceDocumentType> addStateFactory,
            ICollectionCrudEditViewStateFactory<BusinessEntitySourceDocumentType> editStateFactory,
            IEntityCollectionViewModel<BusinessEntitySourceDocumentType> entityCollectionViewModel,
            IViewModelCollectionCreationService<BusinessEntitySourceDocumentType> vmCreationService
            ) : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }
    }
}
