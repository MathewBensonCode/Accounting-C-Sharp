using System.Collections.Generic;
using AccountsViewModel.EntityViewModels;

namespace AccountsViewModel.Services.Interfaces
{
    public interface IViewModelCollectionCreationService<T> where T: class
    {
        void CreateViewModelCollectionFromIEnumerable(
            ICollection<IEntityViewModel<T>> vmCollection,
            IEnumerable<T> collection);
    }
}
