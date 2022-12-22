using System.Collections.Generic;
using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.ListCollectionViewModelStates.AccountListCollectionViewModelStates
{
    public class CurrencyAccountListCollectionViewModelState
        : EntityListCollectionViewModelState<CurrencyAccount>, ICollectionListViewModelState<Account>
    {
        public CurrencyAccountListCollectionViewModelState(
            IRepository<CurrencyAccount> repository,
            ICollection<IEntityViewModel<CurrencyAccount>> collection,
            ICommandViewModelFactory<CurrencyAccount> commandfactory,
            ICollectionCrudAddViewStateFactory<CurrencyAccount> addStateFactory,
            ICollectionCrudEditViewStateFactory<CurrencyAccount> editStateFactory,
            IEntityCollectionViewModel<CurrencyAccount> entityCollectionViewModel,
            IViewModelCollectionCreationService<CurrencyAccount> vmCreationService
            ) : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }

        ICollection<IEntityViewModel<Account>> ICollectionListViewModelState<Account>.EntityCollection => base.EntityCollection as ICollection<IEntityViewModel<Account>>;

        IEntityViewModel<Account> ICollectionViewModelState<Account>.EntityViewModel
        {
            get => EntityViewModel as IEntityViewModel<Account>;
            set => EntityViewModel = value as IEntityViewModel<CurrencyAccount>;
        }
    }
}
