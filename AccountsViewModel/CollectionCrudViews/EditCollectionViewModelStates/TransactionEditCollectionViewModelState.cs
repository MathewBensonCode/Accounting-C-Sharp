using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionCrudViews.Interfaces.AddViewModelStateIInterfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public class TransactionEditCollectionViewModelState
        : TransactionAddEditCollectionViewModelState, ITransactionCollectionEditViewModelState
    {

        public TransactionEditCollectionViewModelState(
            ICollectionListViewModelState<Transaction> listViewModelState,
            IRepository<Transaction> repository,
            IEntityCollectionViewModel<Transaction> collectionViewModel,
            ICommandViewModelFactory<Transaction> commandFactory,
            ITransactionAccountSelectionCollectionViewModelFactory transactionAccountSelectionCollectionViewModelFactory
            ) : base(listViewModelState, repository, collectionViewModel, commandFactory, transactionAccountSelectionCollectionViewModelFactory)
        {
        }

        protected override void CreateSaveCommand()
        {
            SaveCommand = CommandFactory.CreateSaveEditCommand(this as ICollectionEditViewModelState<Transaction>, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
