using AccountsModelCore.Classes;
using AccountsViewModel.CollectionCrudViews.AddCollectionViewModelStates;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.CollectionViewModelStates.AddCollectionViewModelState
{
    public class AddNewBusinessEntitySourceDocumentTypeToCollectionViewModelTests :
        AddNewEntityToCollectionViewModelTests<BusinessEntitySourceDocumentType>
    {
        private readonly Mock<ICollectionListViewModelState<BusinessEntitySourceDocumentType>> businessentitysourcedocumenttypelistviewmodelstate;
        private readonly Mock<IRepository<BusinessEntitySourceDocumentType>> repository;
        private readonly Mock<IEntityCollectionViewModel<BusinessEntitySourceDocumentType>> businessentitysourcedocumenttypecollectionviewmodel;
        private readonly Mock<IEntityCollectionViewModel<DocumentTypeName>> documenttypenamecollectionviewmodel;
        private readonly Mock<ICollectionListViewModelState<DocumentTypeName>> documenttypenamelistviewmodelstate;
        private readonly Mock<ICommandViewModelFactory<BusinessEntitySourceDocumentType>> commandviewmodelfactory;
        private readonly Mock<ICollectionViewModelFactory<DocumentTypeName>> documenttypenamecollectionviewmodelfactory;
        private readonly BusinessEntitySourceDocumentTypeAddCollectionViewModelState sut;

        public AddNewBusinessEntitySourceDocumentTypeToCollectionViewModelTests()
        {
            businessentitysourcedocumenttypelistviewmodelstate = new Mock<ICollectionListViewModelState<BusinessEntitySourceDocumentType>>();
            repository = new Mock<IRepository<BusinessEntitySourceDocumentType>>();
            businessentitysourcedocumenttypecollectionviewmodel = new Mock<IEntityCollectionViewModel<BusinessEntitySourceDocumentType>>();
            documenttypenamecollectionviewmodel = new Mock<IEntityCollectionViewModel<DocumentTypeName>>();
            documenttypenamelistviewmodelstate = new Mock<ICollectionListViewModelState<DocumentTypeName>>();
            commandviewmodelfactory = new Mock<ICommandViewModelFactory<BusinessEntitySourceDocumentType>>();
            documenttypenamecollectionviewmodelfactory = new Mock<ICollectionViewModelFactory<DocumentTypeName>>();

            _ = documenttypenamecollectionviewmodel.Setup(a => a.CollectionViewState)
                .Returns(documenttypenamelistviewmodelstate.Object);

            _ = documenttypenamecollectionviewmodelfactory.Setup(a => a.CreateNewCollectionViewModel(null))
                .Returns(documenttypenamecollectionviewmodel.Object);

            sut = new BusinessEntitySourceDocumentTypeAddCollectionViewModelState(
                businessentitysourcedocumenttypelistviewmodelstate.Object,
                repository.Object,
                businessentitysourcedocumenttypecollectionviewmodel.Object,
                documenttypenamecollectionviewmodelfactory.Object,
                commandviewmodelfactory.Object
                );
        }

        [Fact]
        public void ShouldHaveAPropertyWithACollectionOfDocumentTypeNames()
        {
            Assert.Same(documenttypenamecollectionviewmodel.Object, sut.DocumentTypeNames);
        }

        //[Fact]
        //public void ShouldUpdateSourceDocumentDocumentTypeNameIdWhenBusinessEntitySourceDocumentTypeCollectionViewModelCurrentEntityChanges()
        //{
        //    var testid = 4;
        //    var currentDocumentTypeName = new Mock<IEntityViewModel<DocumentTypeName>>();
        //    currentDocumentTypeName.Setup(a => a.Id).Returns(testid);

        //    var besd = new Mock<IBusinessEntitySourceDocumentTypeViewModel>();
        //    besd.SetupProperty(a => a.DocumentTypeNameId);

        //    sut.Entity = besd.Object;

        //    businessentitysourcedocumenttypelistviewmodelstate.SetupProperty(a => a.Entity);
        //    businessentitysourcedocumenttypecollectionviewmodel.Setup(a => a.CollectionViewState)
        //        .Returns(businessentitysourcedocumenttypelistviewmodelstate.Object);

        //    (sut.DocumentTypeNames.CollectionViewState as ICollectionListViewModelState<DocumentTypeName>).Entity = currentDocumentTypeName.Object;

        //    propChanged.Raise(a => a.PropertyChanged += null, new PropertyChangedEventArgs("DocumentTypeNameId"));
        //    besd.VerifySet(a => a.DocumentTypeNameId = testid);

        //}
    }
}
