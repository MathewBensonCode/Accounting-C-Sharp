using AccountLib.Model;
using Accounts.Repositories;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Unity;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class CountryUnityViewModelFactory :
        UnityViewModelFactory<Country>, ICountryViewModelFactory
    {
        IRepository<Country> _repository;

        public CountryUnityViewModelFactory(IRepository<Country> repository, IUnityContainer container) : base(container)
        {
            _repository = repository;
        }

        public ICountryViewModel CreateCountryViewModelFromBusinessEntity(IBusinessEntity businessEntity)
        {
            var country = _repository.Find(businessEntity.CountryId);
            return CreateViewModelFromEntity(country) as ICountryViewModel;
         }
    }

}
