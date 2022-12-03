using System.Collections.Generic;
using AccountLib.Model;

namespace AccountsViewModel.CollectionCrudViews.Interfaces
{
    public interface IBusinessEntityAddEditCollectionViewModelState
    {
        IEnumerable<Country> CountryList {get;}
    }
}
