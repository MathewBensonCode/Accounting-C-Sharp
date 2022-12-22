using AccountsModelCore.Classes.Accounts;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

namespace AccountsViewModel.CollectionViewModels
{
    public class AccountCollectionViewModel
        : EntityCollectionViewModel<Account>
    {
        public AccountCollectionViewModel(
            IRepository<Account> repository,
            ICollectionCrudListViewStateFactory<Account> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }
    }
}
