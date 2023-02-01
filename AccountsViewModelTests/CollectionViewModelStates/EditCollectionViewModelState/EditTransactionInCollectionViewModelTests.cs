using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates;

namespace AccountsViewModelTests.CollectionViewModelStates.EditCollectionViewModelState
{
    public class EditTransactionToCollectionViewModelTests :
       TransactionAddEditCollectionViewModelTests
    {

        public EditTransactionToCollectionViewModelTests()
        {
            Sut = new TransactionEditCollectionViewModelState(
                Listviewmodelstate.Object,
                Repository.Object,
                Transactioncollectionviewmodel.Object,
                Commandfactory.Object,
                Transactionaccountcollectionviewmodelfactory.Object
                );
        }

        protected override TransactionAddEditCollectionViewModelState Sut { get; set; }
    }
}
