using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ColectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;

namespace AccountsViewModel.Factories.Unity.CollectionViewModelFactories
{
    public class BusinessEntityChildCollectionViewModelFactory :
        IBusinessEntityChildCollectionViewModelFactory
    {
        private readonly ICollectionViewModelFactory<BusinessEntity> _collectionvmfactory;
        private readonly ICollectionViewModelFactory<Person> _personcollectionvmfactory;

        public BusinessEntityChildCollectionViewModelFactory(ICollectionViewModelFactory<BusinessEntity> collectionvmfactory,
            ICollectionViewModelFactory<Person> personcollectionvm)
        {
            _collectionvmfactory = collectionvmfactory;
            _personcollectionvmfactory = personcollectionvm;
        }

        public IEntityCollectionViewModel<Person> GetDirectorsCollectionForCompany(ICompany company)
        {
            return _personcollectionvmfactory.CreateNewCollectionViewModel(company.Directors);
        }

        public IEntityCollectionViewModel<BusinessEntity> GetOwnersOfRegisteredBusiness(IRegisteredBusiness registeredBusiness)
        {
            return _collectionvmfactory.CreateNewCollectionViewModel(registeredBusiness.RegisteredOwners);
        }

        public IEntityCollectionViewModel<BusinessEntity> GetShareHoldersBusinessEntityCollectionForCompany(ICompany company)
        {
            return _collectionvmfactory.CreateNewCollectionViewModel(company.ShareHolders);
        }
    }
}
