using System;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using Unity;

namespace AccountsViewModel.Factories.Unity.CollectionViewModelFactories
{
    public class TransactionAccountSelectionCollectionViewModelFactory
        : ITransactionAccountSelectionCollectionViewModelFactory
    {
        private readonly IUnityContainer _unityContainer;

        public TransactionAccountSelectionCollectionViewModelFactory(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public object GetDebitAccountCollectionViewModelForTransaction(ITransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException();
            }

            object collectionviewmodel = null;

            if (transaction is IAssetPurchaseTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<AssetAccount>), null, null);
            }

            if (transaction is IAssetSaleTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CurrencyAccount>), null, null);
            }

            if (transaction is ICapitalAdditionTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CurrencyAccount>), null, null);
            }

            if (transaction is ICapitalDrawingTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CapitalAccount>), null, null);
            }

            if (transaction is IExpenseTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<ExpenseAccount>), null, null);
            }

            if (transaction is IIncomeTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CurrencyAccount>), null, null);
            }

            if (transaction is ILiabilityDecreaseTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<LiabilityAccount>), null, null);
            }

            if (transaction is ILiabilityIncreaseTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CurrencyAccount>), null, null);
            }

            return collectionviewmodel;
        }

        public object GetCreditAccountCollectionViewModelForTransaction(ITransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException();
            }

            object collectionviewmodel = null;

            if (transaction is IAssetPurchaseTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CurrencyAccount>), null, null);
            }

            if (transaction is IAssetSaleTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<AssetAccount>), null, null);
            }

            if (transaction is ICapitalAdditionTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CapitalAccount>), null, null);
            }

            if (transaction is ICapitalDrawingTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CurrencyAccount>), null, null);
            }

            if (transaction is IExpenseTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CurrencyAccount>), null, null);
            }

            if (transaction is IIncomeTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<IncomeAccount>), null, null);
            }

            if (transaction is ILiabilityDecreaseTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<CurrencyAccount>), null, null);
            }

            if (transaction is ILiabilityIncreaseTransaction)
            {
                collectionviewmodel = _unityContainer.Resolve(typeof(IEntityCollectionViewModel<LiabilityAccount>), null, null);
            }

            return collectionviewmodel;
        }

    }
}
