using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService.AccountViewModelCopyServices
{
    public class LiabilityAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<LiabilityAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<LiabilityAccount> copyfrom, IEntityViewModel<LiabilityAccount> copyto)
        {
            CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
