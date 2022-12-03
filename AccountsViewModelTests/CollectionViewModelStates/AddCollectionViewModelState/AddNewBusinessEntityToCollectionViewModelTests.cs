using AccountLib.Model.BusinessEntities;
using Moq;
using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using Xunit;
using AccountsViewModel.EntityViewModels;
using Prism.Commands;

namespace AccountsViewModelTests.CollectionViewModelStates.AddCollectionViewModelState
{
    public class AddNewBusinessEntityToCollectionViewModelTests
        : BusinessEntityAddEditCollectionViewModelStateTests
    {
        private readonly Mock<ICommandViewModel> addcommandviewmodel;
        private readonly Mock<DelegateCommand> addcommand;
        protected override BusinessEntityAddEditCollectionViewModelState Sut { get; set; }

        public AddNewBusinessEntityToCollectionViewModelTests()
        {
            addcommandviewmodel = new Mock<ICommandViewModel>();
            addcommand = new Mock<DelegateCommand>(() => { });

            _ = addcommandviewmodel.Setup(a => a.Command).Returns(addcommand.Object);

            Sut = new BusinessEntityAddCollectionViewModelState(
                    Businessentitylistcollectionviewmodelstate.Object,
                    Businessentityrepository.Object,
                    Countryrepository.Object,
                    Businessentitycollectionviewmodel.Object,
                    Businessentitycommandviewmodelfactory.Object
                    );

            _ = Businessentitycommandviewmodelfactory.Setup(a => a.CreateSaveNewCommand(Sut as ICollectionAddViewModelState<BusinessEntity>, Businessentitylistcollectionviewmodelstate.Object, Businessentityrepository.Object, Businessentitycollectionviewmodel.Object))
                .Returns(addcommandviewmodel.Object);
        }

        [Fact]
        public void ShouldCreateSaveCommandForAddEntity()
        {
            Sut.EntityViewModel = new Mock<IEntityViewModel<BusinessEntity>>().Object;
            Assert.Same(addcommandviewmodel.Object, Sut.SaveCommand);
        }

    }
}
