using AccountsModelCore.Classes.Transactions;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionCrudViews.Interfaces.EditViewModelStateInterfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates
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
            SaveCommand = CommandFactory.CreateSaveEditCommand(this, ListViewModelState, Repository, CollectionViewModel);
        }
    }
}
