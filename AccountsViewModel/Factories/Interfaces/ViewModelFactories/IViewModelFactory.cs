using AccountsViewModel.EntityViewModels;

namespace AccountsViewModel.Factories.Interfaces
{
    public interface IViewModelFactory<T> where T:class
    {
        IEntityViewModel<T> CreateViewModelFromEntity(T entity);
        IEntityViewModel<T> CreateViewModelForNewEntity();
        IEntityViewModel<T> CreateViewModelForNewEntity(string type);
    }
}
