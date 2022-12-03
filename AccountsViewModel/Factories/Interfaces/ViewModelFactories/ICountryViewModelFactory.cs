using AccountLib.Model;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface ICountryViewModelFactory
        : IViewModelFactory<Country>
    {
        ICountryViewModel CreateCountryViewModelFromBusinessEntity(IBusinessEntity businessEntity);
    }
}
