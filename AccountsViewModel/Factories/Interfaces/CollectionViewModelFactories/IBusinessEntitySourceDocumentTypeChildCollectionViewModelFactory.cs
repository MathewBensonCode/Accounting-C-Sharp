using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsModelCore.Classes;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory
    {
        IEntityCollectionViewModel<BusinessEntitySourceDocumentType> GetBusinessEntitySourceDocumentTypeCollectionViewModelForBusinessEntity(IBusinessEntity entity);
    }
}
