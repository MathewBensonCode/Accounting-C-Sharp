using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates;

namespace AccountsViewModelTests.CollectionViewModelStates.AddCollectionViewModelState
{
    public class AddNewTransactionToCollectionViewModelTests
        : TransactionAddEditCollectionViewModelTests
    {

        public AddNewTransactionToCollectionViewModelTests()
        {

            Sut = new TransactionAddCollectionViewModelState(
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
