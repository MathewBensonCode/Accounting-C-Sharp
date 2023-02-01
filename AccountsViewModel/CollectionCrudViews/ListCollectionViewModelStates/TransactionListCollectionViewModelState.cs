using System.Collections.Generic;
using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.ListCollectionViewModelStates
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
