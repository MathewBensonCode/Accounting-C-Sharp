using System.Collections.Generic;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;

namespace AccountsViewModel.EntityViewModels.Classes.Transactions
{
    public class TransactionViewModel
        : EntityViewModel<Transaction>, ITransactionViewModel
    {
        private readonly IAccountViewModelFactory _accountViewModelFactory;
        private readonly ISourceDocumentViewModelFactory _sourceDocumentViewModelFactory;

        public TransactionViewModel(
            ITransaction entity,
            IAccountViewModelFactory accountViewModelFactory,
            ISourceDocumentViewModelFactory sourceDocumentViewModelFactory,
            IDictionary<string, List<string>> errors
            )
    : base(entity as Transaction, errors)
        {
            _accountViewModelFactory = accountViewModelFactory;
            _sourceDocumentViewModelFactory = sourceDocumentViewModelFactory;
        }

        public TransactionViewModel(
                TransactionViewModel mytype,
                ITransaction entity,
                IAccountViewModelFactory accountViewModelFactory,
                ISourceDocumentViewModelFactory sourceDocumentViewModelFactory,
                IDictionary<string, List<string>> errors
                )
            : base(entity as Transaction, errors)
        {
            DebitAccountId = mytype.DebitAccountId;
            CreditAccountId = mytype.CreditAccountId;
            SourceDocumentId = mytype.SourceDocumentId;
            Amount = mytype.Amount;

            _accountViewModelFactory = accountViewModelFactory;
            _sourceDocumentViewModelFactory = sourceDocumentViewModelFactory;
        }

        public int DebitAccountId
        {
            get => Entity.DebitAccountId;
            set
            {
                Entity.DebitAccountId = value;
                RaisePropertyChanged();
            }
        }

        public IAccountViewModel DebitAccountViewModel => _accountViewModelFactory.GetDebitAccountViewModelForTransaction(Entity);

        public int CreditAccountId
        {
            get => Entity.CreditAccountId;
            set
            {
                Entity.CreditAccountId = value;
                RaisePropertyChanged();
            }
        }

        public IAccountViewModel CreditAccountViewModel => _accountViewModelFactory.GetCreditAccountViewModelForTransaction(Entity);

        public int SourceDocumentId
        {
            get => Entity.SourceDocumentId;
            set
            {
                Entity.SourceDocumentId = value;
                RaisePropertyChanged();
            }
        }

        public ISourceDocumentViewModel SourceDocumentViewModel => _sourceDocumentViewModelFactory.CreateSourceDocumentViewModelForTransaction(Entity);

        public decimal Amount
        {
            get => Entity.Amount;

            set
            {
                Entity.Amount = value;
                RaisePropertyChanged();
            }
        }

    }
}
