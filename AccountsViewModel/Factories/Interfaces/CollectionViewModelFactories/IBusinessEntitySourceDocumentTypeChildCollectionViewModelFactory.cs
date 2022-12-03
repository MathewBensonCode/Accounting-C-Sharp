using AccountLib.Model.Source_Documents;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory
    {
        IEntityCollectionViewModel<BusinessEntitySourceDocumentType> GetBusinessEntitySourceDocumentTypeCollectionViewModelForBusinessEntity(IBusinessEntity entity);
    }
}
