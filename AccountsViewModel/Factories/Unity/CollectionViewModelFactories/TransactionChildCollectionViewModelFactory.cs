using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.SourceDocuments;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsViewModel.Factories.Unity.CollectionViewModelFactories
{
    public class TransactionChildCollectionViewModelFactory
        : ITransactionChildCollectionViewModelFactory
    {
        private readonly ITransactionRepository _repository;
        private readonly ICollectionViewModelFactory<Transaction> _collectionViewModelFactory;

        public TransactionChildCollectionViewModelFactory(
            IRepository<Transaction> repository,
            ICollectionViewModelFactory<Transaction> collectionViewModelFactory
            )
        {
            _repository = repository as ITransactionRepository;
            _collectionViewModelFactory = collectionViewModelFactory;
        }

        public IEntityCollectionViewModel<Transaction> GetCreditsCollectionViewModelForAccount(IAccount account)
        {
            var credittransactioncollection = _repository.GetCreditTransactionsForAccount(account);
            account.Credits = credittransactioncollection;
            return _collectionViewModelFactory.CreateNewCollectionViewModel(credittransactioncollection);
        }

        public IEntityCollectionViewModel<Transaction> GetDebitsCollectionViewModelForAccount(IAccount account)
        {
            var debittransactioncollection = _repository.GetDebitTransactionsForAccount(account);
            account.Debits = debittransactioncollection;
            return _collectionViewModelFactory.CreateNewCollectionViewModel(debittransactioncollection);
        }

        public IEntityCollectionViewModel<Transaction> GetTransactionCollectionViewModelForSourceDocument(ISourceDocument sourceDocument)
        {
            var sourcedocumenttransactioncollection = _repository.GetTransactionsForSourceDocument(sourceDocument);
            sourceDocument.Transactions = sourcedocumenttransactioncollection;
            return _collectionViewModelFactory.CreateNewCollectionViewModel(sourcedocumenttransactioncollection);
        }
    }
}
