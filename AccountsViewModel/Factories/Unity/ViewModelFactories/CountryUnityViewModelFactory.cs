using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class CountryUnityViewModelFactory :
        UnityViewModelFactory<Country>, ICountryViewModelFactory
    {
        private readonly IRepository<Country> _repository;

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
