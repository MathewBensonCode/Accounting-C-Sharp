using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using Accounts.Repositories;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
{
    public class BusinessEntityListCollectionViewModelState
        : EntityListCollectionViewModelState<BusinessEntity>
    {
        public BusinessEntityListCollectionViewModelState(
            IRepository<BusinessEntity> repository, 
            ICollection<IEntityViewModel<BusinessEntity>> collection, 
            ICommandViewModelFactory<BusinessEntity> commandfactory, 
            ICollectionCrudAddViewStateFactory<BusinessEntity> addStateFactory, 
            ICollectionCrudEditViewStateFactory<BusinessEntity> editStateFactory, 
            IEntityCollectionViewModel<BusinessEntity> entityCollectionViewModel, 
            IViewModelCollectionCreationService<BusinessEntity> vmCreationService) 
            : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }
    }
}
