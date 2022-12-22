using AccountLib.Model.BusinessEntities;
using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.EditCollectionViewModelStates;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using Moq;
using Prism.Commands;
using Xunit;

namespace AccountsViewModelTests.CollectionViewModelStates.EditCollectionViewModelState
{
    public class EditBusinessEntityInCollectionViewModelTests
        : BusinessEntityAddEditCollectionViewModelStateTests
    {
        private readonly Mock<ICommandViewModel> editcommandviewmodel;
        private readonly Mock<DelegateCommand> editcommand;
        protected override BusinessEntityAddEditCollectionViewModelState Sut { get; set; }

        public EditBusinessEntityInCollectionViewModelTests()
        {
            editcommandviewmodel = new Mock<ICommandViewModel>();
            editcommand = new Mock<DelegateCommand>(() => { });

            _ = editcommandviewmodel.Setup(a => a.Command).Returns(editcommand.Object);

            Sut = new BusinessEntityEditCollectionViewModelState(
                    Businessentitylistcollectionviewmodelstate.Object,
                    Businessentityrepository.Object,
                    Countryrepository.Object,
                    Businessentitycollectionviewmodel.Object,
                    Businessentitycommandviewmodelfactory.Object
                    );
            _ = Businessentitycommandviewmodelfactory.Setup(a => a.CreateSaveEditCommand(Sut as ICollectionEditViewModelState<BusinessEntity>, Businessentitylistcollectionviewmodelstate.Object, Businessentityrepository.Object, Businessentitycollectionviewmodel.Object))
                .Returns(editcommandviewmodel.Object);
        }

        [Fact]
        public void ShouldCreateSaveCommandForEditEntity()
        {
            Sut.EntityViewModel = new Mock<IEntityViewModel<BusinessEntity>>().Object;
            Assert.Same(editcommandviewmodel.Object, Sut.SaveCommand);
        }

    }
}
