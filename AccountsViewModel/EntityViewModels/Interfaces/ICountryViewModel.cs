using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface ICountryViewModel
        : ICountry, IEntityViewModel<Country>
    {
    }
}
