using System.Collections.Generic;
using AccountsModelCore.Classes;

namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface IBusinessEntityAddEditCollectionViewModelState
    {
        IEnumerable<Country> CountryList { get; }
    }
}
