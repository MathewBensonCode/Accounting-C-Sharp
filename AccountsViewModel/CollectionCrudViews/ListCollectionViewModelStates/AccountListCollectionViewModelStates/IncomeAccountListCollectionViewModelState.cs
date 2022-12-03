using AccountLib.Model.Accounts;
using Accounts.Repositories;
using System.Collections.Generic;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
{
    public class IncomeAccountListCollectionViewModelState
        : EntityListCollectionViewModelState<IncomeAccount>, ICollectionListViewModelState<Account>
    {
        public IncomeAccountListCollectionViewModelState(
            IRepository<IncomeAccount> repository,
            ICollection<IEntityViewModel<IncomeAccount>> collection,
            ICommandViewModelFactory<IncomeAccount> commandfactory,
            ICollectionCrudAddViewStateFactory<IncomeAccount> addStateFactory,
            ICollectionCrudEditViewStateFactory<IncomeAccount> editStateFactory,
            IEntityCollectionViewModel<IncomeAccount> entityCollectionViewModel,
            IViewModelCollectionCreationService<IncomeAccount> vmCreationService
            ) : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }

        ICollection<IEntityViewModel<Account>> ICollectionListViewModelState<Account>.EntityCollection => base.EntityCollection as ICollection<IEntityViewModel<Account>>;

        IEntityViewModel<Account> ICollectionViewModelState<Account>.EntityViewModel
        {
            get => base.EntityViewModel as IEntityViewModel<Account>;
            set
            {
                base.EntityViewModel = value as IEntityViewModel<IncomeAccount>;
            }
        }
    }
}
