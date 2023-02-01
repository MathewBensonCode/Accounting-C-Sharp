using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.ListCollectionViewModelStates
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
