﻿using System.Collections.Generic;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Services.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Repositories.Interfaces;
using AccountsModelCore.Classes.Accounts;

namespace AccountsViewModel.CollectionCrudViews.ListCollectionViewModelStates.AccountListCollectionViewModelStates
{
    public class LiabilityAccountListCollectionViewModelState
        : EntityListCollectionViewModelState<LiabilityAccount>, ICollectionListViewModelState<Account>
    {
        public LiabilityAccountListCollectionViewModelState(
            IRepository<LiabilityAccount> repository,
            ICollection<IEntityViewModel<LiabilityAccount>> collection,
            ICommandViewModelFactory<LiabilityAccount> commandfactory,
            ICollectionCrudAddViewStateFactory<LiabilityAccount> addStateFactory,
            ICollectionCrudEditViewStateFactory<LiabilityAccount> editStateFactory,
            IEntityCollectionViewModel<LiabilityAccount> entityCollectionViewModel,
            IViewModelCollectionCreationService<LiabilityAccount> vmCreationService
            ) : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }

        ICollection<IEntityViewModel<Account>> ICollectionListViewModelState<Account>.EntityCollection => base.EntityCollection as ICollection<IEntityViewModel<Account>>;

        IEntityViewModel<Account> ICollectionViewModelState<Account>.EntityViewModel
        {
            get => EntityViewModel as IEntityViewModel<Account>;
            set => EntityViewModel = value as IEntityViewModel<LiabilityAccount>;
        }
    }
}
