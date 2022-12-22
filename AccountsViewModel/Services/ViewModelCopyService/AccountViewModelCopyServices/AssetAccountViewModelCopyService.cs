using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService.AccountViewModelCopyServices
{
    public class AssetAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<AssetAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<AssetAccount> copyfrom, IEntityViewModel<AssetAccount> copyto)
        {
            CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
