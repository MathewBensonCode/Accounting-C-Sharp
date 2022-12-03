
using AccountLib.Model.Accounts;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class IncomeAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<IncomeAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<IncomeAccount> copyfrom, IEntityViewModel<IncomeAccount> copyto)
        {
            base.CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
