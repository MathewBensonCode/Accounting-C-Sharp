using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface IViewModelFactory<T> where T : class
    {
        IEntityViewModel<T> CreateViewModelFromEntity(T entity);
        IEntityViewModel<T> CreateViewModelForNewEntity();
        IEntityViewModel<T> CreateViewModelForNewEntity(string type);
    }
}
