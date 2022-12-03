
using AccountLib.Model.Accounts;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class CurrencyAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<CurrencyAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<CurrencyAccount> copyfrom, IEntityViewModel<CurrencyAccount> copyto)
        {
            base.CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
