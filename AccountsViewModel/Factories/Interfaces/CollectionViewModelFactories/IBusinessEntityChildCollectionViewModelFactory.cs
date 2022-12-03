using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.ColectionViewModelFactories
{

    public interface IBusinessEntityChildCollectionViewModelFactory
    {
        IEntityCollectionViewModel<BusinessEntity> GetShareHoldersBusinessEntityCollectionForCompany(ICompany company);
        IEntityCollectionViewModel<Person> GetDirectorsCollectionForCompany(ICompany company);
        IEntityCollectionViewModel<BusinessEntity> GetOwnersOfRegisteredBusiness(IRegisteredBusiness registeredBusiness);

    }
}
