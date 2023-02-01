using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService.AccountViewModelCopyServices
{
    public class CapitalAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<CapitalAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<CapitalAccount> copyfrom, IEntityViewModel<CapitalAccount> copyto)
        {
            CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
