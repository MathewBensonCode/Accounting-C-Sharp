using AccountLib.Model.BusinessEntities;
using Accounts.Repositories;
using AccountLib.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Unity;
using Unity.Resolution;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class BusinessEntityUnityViewModelFactory :
        UnityViewModelFactory<BusinessEntity>, IBusinessEntityViewModelFactory
    {
        private readonly IRepository<BusinessEntity> _repository;

        public BusinessEntityUnityViewModelFactory(
            IRepository<BusinessEntity> repository,
            IUnityContainer container) :
            base(container)
        {
            _repository = repository;
        }

        public IBusinessEntityViewModel GetBusinessEntityViewModelForBusinessEntitySourceDocumentType(IBusinessEntitySourceDocumentType businessEntitySourceDocumentType)
        {
            var businessEntity = _repository.Find(businessEntitySourceDocumentType.BusinessEntityId);
            return CreateViewModelFromEntity(businessEntity) as IBusinessEntityViewModel;
        }

        public override IEntityViewModel<BusinessEntity> CreateViewModelFromEntity(BusinessEntity entity)
        {
            IEntityViewModel<BusinessEntity> result = null;
            if (entity is IPerson)
            {
                result = _unityContainer.Resolve(typeof(IEntityViewModel<BusinessEntity>), "Person",
                    new ResolverOverride[]
                    {
                        new ParameterOverride("entity", entity)
                    }) as IEntityViewModel<BusinessEntity>;

            }

            if (entity is IRegisteredBusiness)
            {
                result = _unityContainer.Resolve(typeof(IEntityViewModel<BusinessEntity>), "RegisteredBusiness",
                    new ResolverOverride[]
                    {
                        new ParameterOverride("entity", entity)
                    }) as IEntityViewModel<BusinessEntity>;

            }

            if (entity is ICompany)
            {
                result = _unityContainer.Resolve(typeof(IEntityViewModel<BusinessEntity>), "Company",
                    new ResolverOverride[]
                    {
                        new ParameterOverride("entity", entity)
                    }) as IEntityViewModel<BusinessEntity>;

            }

            return result;
        }
    }
}
