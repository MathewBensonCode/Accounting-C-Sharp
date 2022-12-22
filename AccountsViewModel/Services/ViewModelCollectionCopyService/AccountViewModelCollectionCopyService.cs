using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Accounts;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCollectionCopyService
{
    public class AccountViewModelCollectionCopyService
    : ViewModelCollectionCopyService<Account>
    {
        public AccountViewModelCollectionCopyService
             (
             IViewModelCopyService<Account> viewmodelcopyservice,
             IViewModelFactory<Account> viewmodelfactory
             )
            : base(viewmodelcopyservice, viewmodelfactory)
        {
        }

        protected override string GetEntityType(object entity)
        {
            return entity is IAssetAccount
                ? "AssetAccount"
                : entity is ICapitalAccount
                    ? "CapitalAccount"
                    : entity is ICurrencyAccount
                                    ? "CurrencyAccount"
                                    : entity is IExpenseAccount
                                                    ? "ExpenseAccount"
                                                    : entity is IIncomeAccount ? "IncomeAccount" : entity is ILiabilityAccount ? "LiabilityAccount" : base.GetEntityType(entity);
        }
    }
}
