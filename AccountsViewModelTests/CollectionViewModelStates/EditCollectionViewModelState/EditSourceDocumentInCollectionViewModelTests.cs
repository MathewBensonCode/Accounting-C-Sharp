using AccountsViewModel.CollectionCrudViews;

namespace AccountsViewModelTests.CollectionViewModelStates.EditCollectionViewModelState
{
    public class EditSourceDocumentInCollectionViewModelTests
        : SourceDocumentAddEditCollectionViewModelStateTests
    {
        public EditSourceDocumentInCollectionViewModelTests()
        {
            Sut = new SourceDocumentEditCollectionViewModelState(
                    Sourcedocumentlistcollectionviewmodelstate.Object,
                    Sourcedocumentrepository.Object,
                    Sourcedocumentcollectionviewmodel.Object,
                    Commandfactory.Object,
                    Businessentitycollectionviewmodelfactory.Object,
                    SourceDocumentCollectionAddEditViewModelStateCommandFactory.Object
                    )
            {
                EntityViewModel = Sourcedocumentviewmodel.Object
            };
        }

        protected override SourceDocumentAddEditCollectionViewModelState Sut { get; set; }

    }
}
