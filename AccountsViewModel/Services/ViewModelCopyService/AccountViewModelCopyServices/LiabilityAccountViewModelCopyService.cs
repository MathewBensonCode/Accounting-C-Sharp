using AccountLib.Model.Accounts;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class LiabilityAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<LiabilityAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<LiabilityAccount> copyfrom, IEntityViewModel<LiabilityAccount> copyto)
        {
            base.CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
