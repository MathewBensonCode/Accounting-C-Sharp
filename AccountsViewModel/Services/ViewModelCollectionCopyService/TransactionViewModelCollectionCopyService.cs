using AccountLib.Model.Transactions;
using AccountLib.Interfaces.Transactions;
using AccountsViewModel.Factories.Interfaces;
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
                    if (entity is IAssetPurchaseTransaction)
                        return "AssetPurchaseTransaction";
                    else if (entity is IAssetSaleTransaction)
                        return "AssetSaleTransaction";
                    else if (entity is ICapitalAdditionTransaction)
                        return "CapitalAdditionTransaction";
                    else if (entity is ICapitalDrawingTransaction)
                        return "CapitalDrawingTransaction";
                    else if (entity is IExpenseTransaction)
                        return "ExpenseTransaction";
                    else if (entity is IIncomeTransaction)
                        return "IncomeTransaction";
                    else if (entity is ILiabilityDecreaseTransaction)
                        return "LiabilityDecreaseTransaction";
                    else if (entity is ILiabilityIncreaseTransaction)
                        return "LiabilityIncreaseTransaction";
                    else
                        return base.GetEntityType(entity);
        }
    }
}
