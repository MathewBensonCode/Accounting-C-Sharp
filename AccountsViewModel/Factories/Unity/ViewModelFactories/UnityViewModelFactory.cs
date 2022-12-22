using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class UnityViewModelFactory<T> : IViewModelFactory<T>
        where T : class
    {
        protected IUnityContainer _unityContainer;

        public UnityViewModelFactory(IUnityContainer container)
        {
            _unityContainer = container;
        }

        public virtual IEntityViewModel<T> CreateViewModelForNewEntity()
        {
            return _unityContainer.Resolve(typeof(IEntityViewModel<T>), null) as IEntityViewModel<T>;
        }

        public virtual IEntityViewModel<T> CreateViewModelForNewEntity(string type)
        {
            if (type == "null")
            {
                type = null;
            }

            var viewmodel = _unityContainer.Resolve(typeof(IEntityViewModel<T>), type);
            return viewmodel is IEntityViewModel<T> ? viewmodel as IEntityViewModel<T> : null;
        }

        public virtual IEntityViewModel<T> CreateViewModelFromEntity(T entity)
        {
            return _unityContainer.Resolve(typeof(IEntityViewModel<T>), null, new ResolverOverride[] { new ParameterOverride("entity", entity) }) as IEntityViewModel<T>;
        }
    }
}
