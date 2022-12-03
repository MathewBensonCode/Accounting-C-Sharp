using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using AccountLib.Model.Accounts;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;

namespace AccountsViewModel.CollectionCrudViews
{
    public abstract class TransactionAddEditCollectionViewModelState
        : AddEditEntityCollectionViewModelState<Transaction>, ITransactionCollectionAddEditViewModelState
    {
        private readonly ITransactionAccountSelectionCollectionViewModelFactory _transactionAccountSelectionCollectionViewModelFactory;
        private ICollectionListViewModelState<Account> _currentDebitCollectionListViewModelState;
        private ICollectionListViewModelState<Account> _currentCreditCollectionListViewModelState;

        public TransactionAddEditCollectionViewModelState(
            ICollectionListViewModelState<Transaction> listViewModelState,
            IRepository<Transaction> repository,
            IEntityCollectionViewModel<Transaction> collectionViewModel,
            ICommandViewModelFactory<Transaction> commandfactory,
            ITransactionAccountSelectionCollectionViewModelFactory transactionAccountSelectionCollectionViewModelFactory
       ) : base(listViewModelState, repository, collectionViewModel, commandfactory)
        {
            _transactionAccountSelectionCollectionViewModelFactory = transactionAccountSelectionCollectionViewModelFactory;
            PropertyChanged += UpdateDebitCollectionViewModel;
            PropertyChanged += UpdateCreditCollectionViewModel;

        }

        public object DebitAccountCollectionViewModel
        {
            get; protected set;
        }

        public object CreditAccountCollectionViewModel
        {
            get; protected set;
        }

        private void UpdateDebitCollectionViewModel(object sender, PropertyChangedEventArgs args)
        {
            DebitAccountCollectionViewModel = _transactionAccountSelectionCollectionViewModelFactory.GetDebitAccountCollectionViewModelForTransaction(EntityViewModel.Entity);
            if (_currentDebitCollectionListViewModelState != null)
            {
                _currentDebitCollectionListViewModelState.PropertyChanged -= UpdateCurrentTransactionViewModelIdWhenDebitAccountCollectionViewModelListStateCurrentAccountChanges;
            }

            _currentDebitCollectionListViewModelState = (DebitAccountCollectionViewModel as IEntityCollectionViewModel<Account>).CollectionViewState as ICollectionListViewModelState<Account>;
            _currentDebitCollectionListViewModelState.PropertyChanged += UpdateCurrentTransactionViewModelIdWhenDebitAccountCollectionViewModelListStateCurrentAccountChanges;
        }

        private void UpdateCreditCollectionViewModel(object sender, PropertyChangedEventArgs args)
        {
            CreditAccountCollectionViewModel = _transactionAccountSelectionCollectionViewModelFactory.GetCreditAccountCollectionViewModelForTransaction(EntityViewModel.Entity);
            if (_currentCreditCollectionListViewModelState != null)
            {
                _currentCreditCollectionListViewModelState.PropertyChanged -= UpdateCurrentTransactionViewModelIdWhenCreditAccountCollectionViewModelListStateCurrentAccountChanges;
            }

            _currentCreditCollectionListViewModelState = (CreditAccountCollectionViewModel as IEntityCollectionViewModel<Account>).CollectionViewState as ICollectionListViewModelState<Account>;
            _currentCreditCollectionListViewModelState.PropertyChanged += UpdateCurrentTransactionViewModelIdWhenCreditAccountCollectionViewModelListStateCurrentAccountChanges;

        }

        private void UpdateCurrentTransactionViewModelIdWhenDebitAccountCollectionViewModelListStateCurrentAccountChanges(object sender, PropertyChangedEventArgs args)
        {
            var transactionvm = EntityViewModel as ITransactionViewModel;
            transactionvm.DebitAccountId = _currentDebitCollectionListViewModelState.EntityViewModel.Id;
        }

        private void UpdateCurrentTransactionViewModelIdWhenCreditAccountCollectionViewModelListStateCurrentAccountChanges(object sender, PropertyChangedEventArgs args)
        {
            var transactionvm = EntityViewModel as ITransactionViewModel;
            transactionvm.CreditAccountId = _currentCreditCollectionListViewModelState.EntityViewModel.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is TransactionAddEditCollectionViewModelState state &&
                   EqualityComparer<ICollectionListViewModelState<Account>>.Default.Equals(_currentDebitCollectionListViewModelState, state._currentDebitCollectionListViewModelState);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            return base.SetProperty(ref storage, value, propertyName);
        }

        protected override bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            return base.SetProperty(ref storage, value, onChanged, propertyName);
        }

        [Obsolete]
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
        }

        [Obsolete]
        protected override void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            base.OnPropertyChanged(propertyExpression);
        }

        protected override void CreateSaveCommand()
        {
            throw new NotImplementedException();
        }
    }

}
