
using AccountLib.Model.Accounts;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class CapitalAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<CapitalAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<CapitalAccount> copyfrom, IEntityViewModel<CapitalAccount> copyto)
        {
            base.CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
