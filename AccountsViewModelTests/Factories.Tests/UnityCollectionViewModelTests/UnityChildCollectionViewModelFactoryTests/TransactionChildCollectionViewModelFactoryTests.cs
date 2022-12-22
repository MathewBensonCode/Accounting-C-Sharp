using AccountsViewModel.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using Xunit;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.SourceDocuments;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsViewModelTests.Factories.Tests.UnityCollectionViewModelTests.UnityChildCollectionViewModelFactoryTests
{
    public class TransactionChildCollectionViewModelFactoryTests
    {
        private readonly Mock<IRepository<Transaction>> repository;
        private readonly Mock<ICollectionViewModelFactory<Transaction>> collectionviewmodelfactory;
        private readonly Mock<IAccount> account;
        private readonly Mock<ISourceDocument> sourcedocument;
        private readonly Mock<ICollection<Transaction>> transactioncollection;
        private readonly Mock<IEntityCollectionViewModel<Transaction>> transactioncollectionviewmodel;

        private readonly TransactionChildCollectionViewModelFactory sut;

        public TransactionChildCollectionViewModelFactoryTests()
        {
            repository = new Mock<IRepository<Transaction>>();
            collectionviewmodelfactory = new Mock<ICollectionViewModelFactory<Transaction>>();
            account = new Mock<IAccount>();
            sourcedocument = new Mock<ISourceDocument>();
            transactioncollection = new Mock<ICollection<Transaction>>();
            transactioncollectionviewmodel = new Mock<IEntityCollectionViewModel<Transaction>>();

            repository.As<ITransactionRepository>().Setup(a => a.GetDebitTransactionsForAccount(account.Object))
                .Returns(transactioncollection.Object);
            repository.As<ITransactionRepository>().Setup(a => a.GetCreditTransactionsForAccount(account.Object))
               .Returns(transactioncollection.Object);
            repository.As<ITransactionRepository>().Setup(a => a.GetTransactionsForSourceDocument(sourcedocument.Object))
               .Returns(transactioncollection.Object);

            collectionviewmodelfactory.Setup(a => a.CreateNewCollectionViewModel(transactioncollection.Object)).
                Returns(transactioncollectionviewmodel.Object);

            sut = new TransactionChildCollectionViewModelFactory(
                repository.Object,
                collectionviewmodelfactory.Object);
        }

        [Fact]
        public void ShouldImplementITransactionCollectionViewModelFactory()
        {
            Assert.IsAssignableFrom<ITransactionChildCollectionViewModelFactory>(sut);
        }

        [Fact]
        public void ShouldCreateACollectionOfDebitTransactionsForAnAccount()
        {

            Assert.Equal(transactioncollectionviewmodel.Object, sut.GetDebitsCollectionViewModelForAccount(account.Object));
        }

        [Fact]
        public void ShouldSetTheAccountDebitsWithTheCollectionFromTheRepository()
        {
            sut.GetDebitsCollectionViewModelForAccount(account.Object);
            account.VerifySet(a => a.Debits = transactioncollection.Object);
        }

        [Fact]
        public void ShouldCreateACollectionOfCreditTransactionsForAnAccount()
        {
            Assert.Equal(transactioncollectionviewmodel.Object, sut.GetCreditsCollectionViewModelForAccount(account.Object));
        }

        [Fact]
        public void ShouldSetTheAccountCreditsWithTheCollectionFromTheRepository()
        {

            sut.GetCreditsCollectionViewModelForAccount(account.Object);
            account.VerifySet(a => a.Credits = transactioncollection.Object);
        }

        [Fact]
        public void ShouldCreateACollectionOfTransactionsForASourceDocument()
        {
            collectionviewmodelfactory.Setup(a => a.CreateNewCollectionViewModel(transactioncollection.Object)).
                Returns(transactioncollectionviewmodel.Object);
            Assert.Equal(transactioncollectionviewmodel.Object, sut.GetTransactionCollectionViewModelForSourceDocument(sourcedocument.Object));
        }

        [Fact]
        public void ShouldSetTheSourceDocumentTransactionsWithTheCollectionFromTheRepository()
        {
            sut.GetTransactionCollectionViewModelForSourceDocument(sourcedocument.Object);
            sourcedocument.VerifySet(a => a.Transactions = transactioncollection.Object);
        }

    }
}
