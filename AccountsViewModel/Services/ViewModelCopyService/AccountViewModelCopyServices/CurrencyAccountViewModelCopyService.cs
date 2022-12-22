using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService.AccountViewModelCopyServices
{
    public class CurrencyAccountViewModelCopyService
        : AccountViewModelCopyService, IViewModelCopyService<CurrencyAccount>
    {
        public void CopyEntityViewModel(IEntityViewModel<CurrencyAccount> copyfrom, IEntityViewModel<CurrencyAccount> copyto)
        {
            CopyEntityViewModel(copyfrom as IEntityViewModel<Account>, copyto as IEntityViewModel<Account>);
        }
    }
}
