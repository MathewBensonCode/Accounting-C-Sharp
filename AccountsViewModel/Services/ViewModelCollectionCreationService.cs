using System.Collections.Generic;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services
{
    public class ViewModelCollectionCreationService<T> :
        IViewModelCollectionCreationService<T> where T : class
    {
        IViewModelFactory<T> _viewModelFactory;

        public ViewModelCollectionCreationService(IViewModelFactory<T> factory)
        {
            _viewModelFactory = factory;
        }

        public void CreateViewModelCollectionFromIEnumerable(
            ICollection<IEntityViewModel<T>> vmCollection,
            IEnumerable<T> collection)
        {
            foreach (T entity in collection)
            {
                vmCollection.Add(_viewModelFactory.CreateViewModelFromEntity(entity));   
            }
        }
    }
}
