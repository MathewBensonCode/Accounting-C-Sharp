using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsModelCore.Classes;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface ICountryViewModelFactory
        : IViewModelFactory<Country>
    {
        ICountryViewModel CreateCountryViewModelFromBusinessEntity(IBusinessEntity businessEntity);
    }
}
