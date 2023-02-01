using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService.AccountViewModelCopyServices
{
    public class ExpenseAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<ExpenseAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<ExpenseAccount> copyfrom, IEntityViewModel<ExpenseAccount> copyto)
        {
            CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
