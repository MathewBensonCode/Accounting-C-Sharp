using AccountLib.Model.Accounts;
using AccountsViewModel.Entity.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class AccountViewModelCopyService
        : IViewModelCopyService<Account>
    {
        public void CopyEntityViewModel(IEntityViewModel<Account> copyfrom, IEntityViewModel<Account> copyto)
        {
            var orig = copyfrom as IAccountViewModel;
            var copy = copyto as IAccountViewModel;

            copy.Name = orig.Name;
        }
    }
}
