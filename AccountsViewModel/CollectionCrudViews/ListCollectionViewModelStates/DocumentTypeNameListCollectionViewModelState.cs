using System.Collections.Generic;
using Accounts.Repositories;
using AccountLib.Model;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
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
