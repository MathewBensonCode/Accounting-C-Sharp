using System.Collections.Generic;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories
{
    public interface ICollectionViewModelFactory<T> where T : class
    {
        IEntityCollectionViewModel<T> CreateNewCollectionViewModel(ICollection<T> collection);
    }
}
