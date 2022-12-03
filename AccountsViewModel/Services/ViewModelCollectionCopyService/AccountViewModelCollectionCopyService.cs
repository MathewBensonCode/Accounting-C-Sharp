using AccountLib.Model.Accounts;
using AccountLib.Interfaces.Accounts;
using AccountsViewModel.Factories.Interfaces;
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
            if(entity is IAssetAccount)
                return "AssetAccount";
            else if(entity is ICapitalAccount)
                return "CapitalAccount";
            else if(entity is ICurrencyAccount)
                return "CurrencyAccount";
            else if(entity is IExpenseAccount)
                return "ExpenseAccount";
            else if(entity is IIncomeAccount)
                return "IncomeAccount";
            else if(entity is ILiabilityAccount)
                return "LiabilityAccount";
            else
                return base.GetEntityType(entity);
        }
    }
}
