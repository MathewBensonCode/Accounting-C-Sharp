using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCollectionCopyService
{
    public class TransactionViewModelCollectionCopyService
        : ViewModelCollectionCopyService<Transaction>
    {
        public TransactionViewModelCollectionCopyService
            (
             IViewModelCopyService<Transaction> viewmodelcopyservice,
             IViewModelFactory<Transaction> viewmodelfactory
             )
            : base(viewmodelcopyservice, viewmodelfactory)
        {
        }

        protected override string GetEntityType(object entity)
        {
            return entity is IAssetPurchaseTransaction
                ? "AssetPurchaseTransaction"
                : entity is IAssetSaleTransaction
                    ? "AssetSaleTransaction"
                    : entity is ICapitalAdditionTransaction
                                    ? "CapitalAdditionTransaction"
                                    : entity is ICapitalDrawingTransaction
                                                    ? "CapitalDrawingTransaction"
                                                    : entity is IExpenseTransaction
                                                                    ? "ExpenseTransaction"
                                                                    : entity is IIncomeTransaction
                                                                                    ? "IncomeTransaction"
                                                                                    : entity is ILiabilityDecreaseTransaction
                                                                                                    ? "LiabilityDecreaseTransaction"
                                                                                                    : entity is ILiabilityIncreaseTransaction ? "LiabilityIncreaseTransaction" : base.GetEntityType(entity);
        }
    }
}
