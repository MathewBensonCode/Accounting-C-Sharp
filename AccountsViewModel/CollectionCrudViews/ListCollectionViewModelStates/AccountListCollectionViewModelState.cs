using System.Collections.Generic;
using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
{
    public class AccountListCollectionViewModelState
        : EntityListCollectionViewModelState<Account>
    {
        public AccountListCollectionViewModelState(
            IRepository<Account> repository, 
            ICollection<IEntityViewModel<Account>> collection, 
            ICommandViewModelFactory<Account> commandfactory, 
            ICollectionCrudAddViewStateFactory<Account> addStateFactory, 
            ICollectionCrudEditViewStateFactory<Account> editStateFactory, 
            IEntityCollectionViewModel<Account> entityCollectionViewModel, 
            IViewModelCollectionCreationService<Account> vmCreationService) 
            : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }
    }
}
