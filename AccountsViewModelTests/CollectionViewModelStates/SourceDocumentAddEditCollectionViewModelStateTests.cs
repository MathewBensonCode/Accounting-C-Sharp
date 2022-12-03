using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AccountLib.Model.BusinessEntities;
using AccountLib.Model.Source_Documents;
using AccountLib.Model.SourceDocuments;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using Moq;
using Prism.Commands;
using Xunit;

namespace AccountsViewModelTests.CollectionViewModelStates
{
    public abstract class SourceDocumentAddEditCollectionViewModelStateTests
    {
        protected abstract SourceDocumentAddEditCollectionViewModelState Sut { get; set; }
        protected Mock<ICollectionListViewModelState<SourceDocument>> Sourcedocumentlistcollectionviewmodelstate { get; set; }
        protected Mock<IRepository<SourceDocument>> Sourcedocumentrepository { get; set; }
        protected Mock<IEntityCollectionViewModel<SourceDocument>> Sourcedocumentcollectionviewmodel { get; set; }
        protected Mock<ISourceDocumentViewModel> Sourcedocumentviewmodel { get; set; }
        protected Mock<IEntityCollectionViewModel<BusinessEntity>> Businessentitycollectionviewmodel { get; set; }
        protected Mock<ICollectionViewModelFactory<BusinessEntity>> Businessentitycollectionviewmodelfactory { get; set; }
        protected Mock<ISourceDocumentCollectionAddEditViewModelStateCommandFactory> SourceDocumentCollectionAddEditViewModelStateCommandFactory { get; set; }
        protected Mock<ICommandViewModelFactory<SourceDocument>> Commandfactory { get; set; }
        protected Mock<ICommandViewModel> Readfromimagetextcommand { get; set; }
        protected Mock<ICommandViewModel> Savecommandviewmodel { get; set; }
        protected DelegateCommand Savecommand { get; set; }
        protected Mock<ICollectionListViewModelState<DocumentImage>> Imagelistcollectionviewmodelstate { get; set; }
        protected Mock<ICollectionAddEditViewModelState<DocumentImage>> Imageaddeditcollectionviewmodlestate { get; set; }
        protected Mock<IEntityCollectionViewModel<DocumentImage>> Imagecollectionviewmodel { get; set; }
        protected Mock<ICollectionListViewModelState<BusinessEntity>> Businessentitylistcollectionviewmodelstate { get; set; }
        protected Mock<ICollectionAddEditViewModelState<BusinessEntity>> Businessentityaddeditcollectionviewmodlestate { get; set; }
        protected Mock<IEntityCollectionViewModel<Transaction>> Transactioncollectionviewmodel { get; set; }
        protected Mock<ICollectionListViewModelState<Transaction>> Transactionlistcollectionviewmodelstate { get; set; }
        protected Mock<ICollectionAddEditViewModelState<Transaction>> Transactionaddeditcollectionviewmodelstate { get; set; }
        protected Mock<IEntityCollectionViewModel<BusinessEntitySourceDocumentType>> Businessentitysourcedocumenttypecollectionviewmodel { get; set; }
        protected Mock<ICollectionListViewModelState<BusinessEntitySourceDocumentType>> Businessentitysourcedocumenttypelistcollectionviewmodelstate { get; set; }

        protected ObservableCollection<IEntityViewModel<DocumentImage>> Imagecollection { get; set; }
        protected ObservableCollection<IEntityViewModel<BusinessEntitySourceDocumentType>> Businessentitysourcedocumenttypecollection { get; set; }
        public string String1 { get; private set; }
        public string String2 { get; private set; }

        public SourceDocumentAddEditCollectionViewModelStateTests()
        {
            Sourcedocumentlistcollectionviewmodelstate = new Mock<ICollectionListViewModelState<SourceDocument>>();
            Sourcedocumentrepository = new Mock<IRepository<SourceDocument>>();
            Sourcedocumentcollectionviewmodel = new Mock<IEntityCollectionViewModel<SourceDocument>>();
            Sourcedocumentviewmodel = new Mock<ISourceDocumentViewModel>();
            Imagecollectionviewmodel = new Mock<IEntityCollectionViewModel<DocumentImage>>();
            Businessentitycollectionviewmodel = new Mock<IEntityCollectionViewModel<BusinessEntity>>();
            Businessentitycollectionviewmodelfactory = new Mock<ICollectionViewModelFactory<BusinessEntity>>();
            SourceDocumentCollectionAddEditViewModelStateCommandFactory = new Mock<ISourceDocumentCollectionAddEditViewModelStateCommandFactory>();
            Commandfactory = new Mock<ICommandViewModelFactory<SourceDocument>>();
            Readfromimagetextcommand = new Mock<ICommandViewModel>();
            Savecommandviewmodel = new Mock<ICommandViewModel>();
            Savecommand = new DelegateCommand(() => { });
            Imagelistcollectionviewmodelstate = new Mock<ICollectionListViewModelState<DocumentImage>>();
            Imageaddeditcollectionviewmodlestate = new Mock<ICollectionAddEditViewModelState<DocumentImage>>();
            Businessentitylistcollectionviewmodelstate = new Mock<ICollectionListViewModelState<BusinessEntity>>();
            Businessentityaddeditcollectionviewmodlestate = new Mock<ICollectionAddEditViewModelState<BusinessEntity>>();
            Transactioncollectionviewmodel = new Mock<IEntityCollectionViewModel<Transaction>>();
            Transactionlistcollectionviewmodelstate = new Mock<ICollectionListViewModelState<Transaction>>();
            Transactionaddeditcollectionviewmodelstate = new Mock<ICollectionAddEditViewModelState<Transaction>>();
            Imagecollection = new ObservableCollection<IEntityViewModel<DocumentImage>>();
            Businessentitysourcedocumenttypecollection = new ObservableCollection<IEntityViewModel<BusinessEntitySourceDocumentType>>();
            Businessentitysourcedocumenttypecollectionviewmodel = new Mock<IEntityCollectionViewModel<BusinessEntitySourceDocumentType>>();
            Businessentitysourcedocumenttypelistcollectionviewmodelstate = new Mock<ICollectionListViewModelState<BusinessEntitySourceDocumentType>>();

            _ = Savecommandviewmodel.Setup(a => a.Command)
                .Returns(Savecommand);

            _ = Commandfactory
                .Setup(a => a.CreateSaveNewCommand(
                It.IsAny<ICollectionAddViewModelState<SourceDocument>>(),
                It.IsAny<ICollectionListViewModelState<SourceDocument>>(),
                It.IsAny<IRepository<SourceDocument>>(),
                It.IsAny<IEntityCollectionViewModel<SourceDocument>>()
                ))
                .Returns(Savecommandviewmodel.Object);

            _ = Commandfactory
                    .Setup(a => a.CreateSaveEditCommand(
                    It.IsAny<ICollectionEditViewModelState<SourceDocument>>(),
                    It.IsAny<ICollectionListViewModelState<SourceDocument>>(),
                    It.IsAny<IRepository<SourceDocument>>(),
                    It.IsAny<IEntityCollectionViewModel<SourceDocument>>()
                    ))
                    .Returns(Savecommandviewmodel.Object);

            _ = Businessentitycollectionviewmodelfactory.Setup(a => a.CreateNewCollectionViewModel(null))
                                                        .Returns(Businessentitycollectionviewmodel.Object);

            _ = Imagelistcollectionviewmodelstate.Setup(a => a.EntityCollection)
                                                 .Returns((System.Collections.Generic.ICollection<IEntityViewModel<DocumentImage>>)Imagecollection);

            _ = Imagecollectionviewmodel.Setup(a => a.CollectionViewState)
                                        .Returns(Imagelistcollectionviewmodelstate.Object);

            _ = Businessentitycollectionviewmodel.Setup(a => a.CollectionViewState)
                                                 .Returns(Businessentitylistcollectionviewmodelstate.Object);

            _ = Transactioncollectionviewmodel.Setup(a => a.CollectionViewState)
                                              .Returns(Transactionlistcollectionviewmodelstate.Object);

            _ = Sourcedocumentviewmodel.Setup(a => a.ImageCollectionViewModel)
                                       .Returns(Imagecollectionviewmodel.Object);

            _ = Sourcedocumentviewmodel.Setup(a => a.TransactionCollectionViewModel)
                                       .Returns(Transactioncollectionviewmodel.Object);

            _ = Businessentitysourcedocumenttypelistcollectionviewmodelstate.Setup(a => a.EntityCollection)
                                                                            .Returns((System.Collections.Generic.ICollection<IEntityViewModel<BusinessEntitySourceDocumentType>>)Businessentitysourcedocumenttypecollection);

            _ = Businessentitysourcedocumenttypecollectionviewmodel.Setup(a => a.CollectionViewState)
                                                                   .Returns(Businessentitysourcedocumenttypelistcollectionviewmodelstate.Object);

            _ = SourceDocumentCollectionAddEditViewModelStateCommandFactory.Setup(a => a.CreateReadFromImageTextCommand(It.IsAny<ISourceDocumentCollectionAddEditViewModelState>()))
                                                                           .Returns(Readfromimagetextcommand.Object);

            String1 = string.Empty;
            String2 = string.Empty;

            SetupImageStrings();

        }

        [Fact]
        public void ShouldHaveAPropertyWithACollectionOfBusinessEntities()
        {
            Assert.Same(Businessentitycollectionviewmodel.Object, Sut.BusinessEntityCollectionViewModel);
        }

        [Fact]
        public void ShouldCreateReadTextFromImageCommandCommandViewModel()
        {
            Assert.Same(Readfromimagetextcommand.Object, Sut.ReadTextFromImageCommand);
        }

        protected void SetupImageStrings()
        {
            String1 = "TextFromFirstImage";
            String2 = "TextFromSecondImage";

            Mock<IDocumentImageViewModel> imageviewmodel1 = new();
            _ = imageviewmodel1.Setup(a => a.SourceDocumentText)
                .Returns(String1);
            Mock<IDocumentImageViewModel> imageviewmodel2 = new();
            _ = imageviewmodel2.Setup(a => a.SourceDocumentText)
                .Returns(String2);

            Imagecollection = new ObservableCollection<IEntityViewModel<DocumentImage>> {
                imageviewmodel1.Object,
                imageviewmodel2.Object
            };

            Imagelistcollectionviewmodelstate = new Mock<ICollectionListViewModelState<DocumentImage>>();

            _ = Imagelistcollectionviewmodelstate.Setup(a => a.EntityCollection)
                .Returns((System.Collections.Generic.ICollection<IEntityViewModel<DocumentImage>>)Imagecollection);

            _ = Imagecollectionviewmodel.Setup(a => a.CollectionViewState)
                .Returns(Imagelistcollectionviewmodelstate.Object);
        }

        [Fact]
        public void ShouldHaveASourceDocumentTextPropertyWithTextOfCombinedImages()
        {
            Assert.Equal(String1 + "\n" + String2 + "\n", Sut.SourceDocumentText);
        }

        [Fact]
        public void ShouldRaisePropertyChangedOnSourceDocumentTextWhenImageTextAdded()
        {

            Mock<IDocumentImageViewModel> documentimageviewmodel = new Mock<IDocumentImageViewModel>();
            documentimageviewmodel.Setup(a => a.SourceDocumentText)
                                                    .Returns("TextFromThirdImage");

            Assert.PropertyChanged(Sut, "SourceDocumentText", () =>
            {
                Imagecollection.Add(new Mock<IDocumentImageViewModel>().Object);
            });
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheVisibilityForTheImagePanel()
        {
            _ = Assert.IsType<bool>(Sut.ImagePanelVisible);
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheVisibilityForTheSourceDocumentTextPanel()
        {
            _ = Assert.IsType<bool>(Sut.SourceDocumentTextPanelVisible);
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheVisibilityForTheBusinessEntityPanel()
        {
            _ = Assert.IsType<bool>(Sut.BusinessEntityPanelVisible);
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheVisibilityForTheDateAndTransactionsPanel()
        {
            _ = Assert.IsType<bool>(Sut.DateAndTransactionsPanelVisible);
        }

        [Fact]
        public void ImagePanelShouldNotBeVisibleWhenAddingOrEditingBusinessEntity()
        {
            SetupPropertyChangedOnBusinessEntityCollectionViewModel();
            Assert.False(Sut.ImagePanelVisible);
        }

        [Fact]
        public void ImagePanelShouldNotBeVisibleWhenAddingOrEditingTransactions()
        {
            SetupPropertyChangedOnTransactionCollectionViewModel();
            Assert.False(Sut.ImagePanelVisible);
        }

        [Fact]
        public void SourceDocumentTextPanelShouldNotBeVisibleWhenThereIsNoImage()
        {
            Imagecollection.Clear();
            Assert.False(Sut.SourceDocumentTextPanelVisible);
        }

        [Fact]
        public void SourceDocumentTextPanelShouldBeVisibleWhenThereAreImagesWithText()
        {
            Assert.True(Sut.SourceDocumentTextPanelVisible);
        }

        [Fact]
        public void SourceDocumentTextPanelShouldNotBeVisibleWhenAddingOrEditingImage()
        {
            SetupPropertyChangedOnImageCollectionViewModel();
            Assert.False(Sut.SourceDocumentTextPanelVisible);
        }

        [Fact]
        public void BusinessEntityPanelShouldNotBeVisibleWhenThereIsNoSourceDocumentText()
        {
            Imagecollection.Clear();
            Assert.False(Sut.BusinessEntityPanelVisible);
        }

        [Fact]
        public void BusinessEntityPanelShouldBeVisibleWhenTheSourceDocumentTextIsVisible()
        {
            Assert.True(Sut.BusinessEntityPanelVisible);
        }

        [Fact]
        public void BusinessEntityPanelShouldNotBeVisibleWhenAddingOrEditingImage()
        {
            SetupPropertyChangedOnImageCollectionViewModel();
            Assert.False(Sut.BusinessEntityPanelVisible);
        }

        [Fact]
        public void BusinessEntityPanelShouldNotBeVisibleWhenAddingOrEditingTransaction()
        {
            SetupPropertyChangedOnTransactionCollectionViewModel();
            Assert.False(Sut.BusinessEntityPanelVisible);
        }

        [Fact]
        public void DateAndTransactionsPanelShouldNotBeVisibleWhenThereIsNoSourceDocumentText()
        {
            Imagecollection.Clear();
            Assert.False(Sut.DateAndTransactionsPanelVisible);
        }

        [Fact]
        public void DateAndTransactionsPanelShouldBeVisibleWhenTheSourceDocumentTextIsVisible()
        {
            SetupPropertyChangedOnSourceDocumentTextAdded();
            Assert.True(Sut.DateAndTransactionsPanelVisible);
        }

        private void SetupPropertyChangedOnSourceDocumentTextAdded()
        {
            SetupImageStrings();
            _ = Imagecollectionviewmodel.Setup(a => a.CollectionViewState)
                .Returns(Imagelistcollectionviewmodelstate.Object);
            Imagecollectionviewmodel.Object.CollectionViewState = Imagelistcollectionviewmodelstate.Object;
            Imagecollectionviewmodel.Raise(a => a.PropertyChanged += null, this, new PropertyChangedEventArgs("CollectionViewState"));
        }

        [Fact]
        public void DateAndTransactionsPanelShouldNotBeVisibleWhenAddingOrEditingImage()
        {
            SetupPropertyChangedOnImageCollectionViewModel();
            Assert.False(Sut.DateAndTransactionsPanelVisible);
        }

        [Fact]
        public void DateAndTransactionsPanelShouldNotBeVisibleWhenAddingOrEditingBusinessEntity()
        {
            SetupPropertyChangedOnBusinessEntityCollectionViewModel();
            Assert.False(Sut.DateAndTransactionsPanelVisible);
        }

        private void SetupPropertyChangedOnImageCollectionViewModel()
        {
            _ = Imagecollectionviewmodel.SetupProperty(a => a.CollectionViewState);
            Imagecollectionviewmodel.Object.CollectionViewState = Imageaddeditcollectionviewmodlestate.Object;
            Imagecollectionviewmodel.Raise(a => a.PropertyChanged += null, this, new PropertyChangedEventArgs("CollectionViewState"));
        }

        private void SetupPropertyChangedOnBusinessEntityCollectionViewModel()
        {
            _ = Businessentitycollectionviewmodel.SetupProperty(a => a.CollectionViewState);
            Businessentitycollectionviewmodel.Object.CollectionViewState = Businessentityaddeditcollectionviewmodlestate.Object;
            Businessentitycollectionviewmodel.Raise(a => a.PropertyChanged += null, this, new PropertyChangedEventArgs("CollectionViewState"));
        }

        private void SetupPropertyChangedOnTransactionCollectionViewModel()
        {
            _ = Transactioncollectionviewmodel.SetupProperty(a => a.CollectionViewState);
            Transactioncollectionviewmodel.Object.CollectionViewState = Transactionaddeditcollectionviewmodelstate.Object;
            Transactioncollectionviewmodel.Raise(a => a.PropertyChanged += null, this, new PropertyChangedEventArgs("CollectionViewState"));
        }

        [Fact]
        public void ShouldUpdateSourceDocumentBusinessEntitySourceDocumentTypeIdWhenBusinessEntityCollectionViewModelCurrentEntityChanges()
        {
            Mock<IBusinessEntityViewModel> businessentityviewmodel = new();

            _ = businessentityviewmodel.Setup(a => a.BusinessEntitySourceDocumentTypes)
                .Returns(Businessentitysourcedocumenttypecollectionviewmodel.Object);

            _ = Sourcedocumentviewmodel.SetupProperty(a => a.BusinessEntitySourceDocumentTypeId);

            _ = Businessentitylistcollectionviewmodelstate.SetupProperty(a => a.EntityViewModel);
            Businessentitylistcollectionviewmodelstate.Object.EntityViewModel = businessentityviewmodel.As<IEntityViewModel<BusinessEntity>>().Object;
            Businessentitylistcollectionviewmodelstate.Raise(a => a.PropertyChanged += null, this, new PropertyChangedEventArgs("EntityViewModel"));

            _ = Businessentitysourcedocumenttypelistcollectionviewmodelstate.SetupProperty(a => a.EntityViewModel);
            Mock<IEntityViewModel<BusinessEntitySourceDocumentType>> businessentitysourcedocumenttype = new();
            businessentitysourcedocumenttype.Setup(a => a.Id).Returns(4);
            Businessentitysourcedocumenttypelistcollectionviewmodelstate.Object.EntityViewModel = businessentitysourcedocumenttype.Object;
            Businessentitysourcedocumenttypelistcollectionviewmodelstate.Raise(a => a.PropertyChanged += null, this, new PropertyChangedEventArgs("EntityViewModel"));

            Sut.EntityViewModel = Sourcedocumentviewmodel.Object;

            Assert.Equal(4, Sourcedocumentviewmodel.Object.BusinessEntitySourceDocumentTypeId);
        }
    }
}
