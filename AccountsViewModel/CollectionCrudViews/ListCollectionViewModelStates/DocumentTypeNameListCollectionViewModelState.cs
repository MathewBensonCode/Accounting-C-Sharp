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
    public class DocumentTypeNameListCollectionViewModelState :
        EntityListCollectionViewModelState<DocumentTypeName>
    {
        public DocumentTypeNameListCollectionViewModelState(
            IRepository<DocumentTypeName> repository,
            ICollection<IEntityViewModel<DocumentTypeName>> collection,
            ICommandViewModelFactory<DocumentTypeName> commandfactory,
            ICollectionCrudAddViewStateFactory<DocumentTypeName> addStateFactory,
            ICollectionCrudEditViewStateFactory<DocumentTypeName> editStateFactory,
            IEntityCollectionViewModel<DocumentTypeName> entityCollectionViewModel,
            IViewModelCollectionCreationService<DocumentTypeName> vmCreationService
            ) : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }
    }
}
