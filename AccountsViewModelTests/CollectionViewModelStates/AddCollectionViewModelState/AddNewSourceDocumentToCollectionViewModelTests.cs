using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates;

namespace AccountsViewModelTests.CollectionViewModelStates.AddCollectionViewModelState
{
    public class AddNewSourceDocumentToCollectionViewModelTests
        : SourceDocumentAddEditCollectionViewModelStateTests
    {
        protected override SourceDocumentAddEditCollectionViewModelState Sut { get; set; }

        public AddNewSourceDocumentToCollectionViewModelTests()
        {
            Sut = new SourceDocumentAddCollectionViewModelState(
                    Sourcedocumentlistcollectionviewmodelstate.Object,
                    Sourcedocumentrepository.Object,
                    Sourcedocumentcollectionviewmodel.Object,
                    Businessentitycollectionviewmodelfactory.Object,
                    SourceDocumentCollectionAddEditViewModelStateCommandFactory.Object,
                    Commandfactory.Object
                    )
            {
                EntityViewModel = Sourcedocumentviewmodel.Object
            };
        }

    }
}
