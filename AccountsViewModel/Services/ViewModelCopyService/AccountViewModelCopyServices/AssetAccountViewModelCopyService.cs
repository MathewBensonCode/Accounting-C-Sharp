using AccountLib.Model.Accounts;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class AssetAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<AssetAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<AssetAccount> copyfrom, IEntityViewModel<AssetAccount> copyto)
        {
            base.CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
