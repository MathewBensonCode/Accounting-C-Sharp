using AccountLib.Interfaces;
using AccountLib.Model;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface ICountryViewModel
        : ICountry, IEntityViewModel<Country>
    {
    }
}
