
using System.Collections.Generic;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
{
    public class TransactionListCollectionViewModelState
        : EntityListCollectionViewModelState<Transaction>
    {
        public TransactionListCollectionViewModelState(
            IRepository<Transaction> repository, 
            ICollection<IEntityViewModel<Transaction>> collection, 
            ICommandViewModelFactory<Transaction> commandfactory, 
            ICollectionCrudAddViewStateFactory<Transaction> addStateFactory, 
            ICollectionCrudEditViewStateFactory<Transaction> editStateFactory, 
            IEntityCollectionViewModel<Transaction> entityCollectionViewModel, 
            IViewModelCollectionCreationService<Transaction> vmCreationService) 
            : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }
    }
}
