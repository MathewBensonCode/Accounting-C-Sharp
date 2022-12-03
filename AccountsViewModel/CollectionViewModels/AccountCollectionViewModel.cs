using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

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
