using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService.AccountViewModelCopyServices
{
    public class IncomeAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<IncomeAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<IncomeAccount> copyfrom, IEntityViewModel<IncomeAccount> copyto)
        {
            CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
