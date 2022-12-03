using AccountLib.Model.BusinessEntities;
using Accounts.Repositories;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;

namespace AccountsViewModel.CollectionViewModels
{
    public class BusinessEntityCollectionViewModel
        : EntityCollectionViewModel<BusinessEntity>
    {
        public BusinessEntityCollectionViewModel(
            IRepository<BusinessEntity> repository, 
            ICollectionCrudListViewStateFactory<BusinessEntity> viewstatefactory
            ) : base(repository, viewstatefactory)
        {
        }
    }
}
