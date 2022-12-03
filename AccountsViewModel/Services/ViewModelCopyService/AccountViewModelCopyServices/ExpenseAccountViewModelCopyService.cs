
using AccountLib.Model.Accounts;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class ExpenseAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<ExpenseAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<ExpenseAccount> copyfrom, IEntityViewModel<ExpenseAccount> copyto)
        {
            base.CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
