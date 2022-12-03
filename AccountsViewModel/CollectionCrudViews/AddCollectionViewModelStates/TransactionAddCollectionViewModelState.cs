using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionCrudViews.Interfaces.AddViewModelStateIInterfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public class TransactionAddCollectionViewModelState
        : TransactionAddEditCollectionViewModelState, ITransactionCollectionAddViewModelState
    {
        public TransactionAddCollectionViewModelState(
            ICollectionListViewModelState<Transaction> listViewModelState,
            IRepository<Transaction> repository,
            IEntityCollectionViewModel<Transaction> collectionViewModel,
            ICommandViewModelFactory<Transaction> commandfactory,
            ITransactionAccountSelectionCollectionViewModelFactory transactionAccountSelectionCollectionViewModelFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandfactory, transactionAccountSelectionCollectionViewModelFactory)
        {
        }

        protected override void CreateSaveCommand()
        {
                SaveCommand = CommandFactory.CreateSaveNewCommand(this as ICollectionAddViewModelState<Transaction>, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
