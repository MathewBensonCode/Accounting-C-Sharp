using AccountLib.Model.BusinessEntities;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Repositories.Interfaces;

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
