using System;
using AccountLib.Model.Transactions;
using AccountLib.Interfaces.Transactions;
using AccountsViewModel.EntityViewModels;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class TransactionUnityViewModelFactory
        : UnityViewModelFactory<Transaction>
    {
        public TransactionUnityViewModelFactory(IUnityContainer container)
            : base(container)
        {
        }

        public override IEntityViewModel<Transaction> CreateViewModelForNewEntity()
        {
            throw new ArgumentNullException("New Entity Type");
        }

        public override IEntityViewModel<Transaction> CreateViewModelForNewEntity(string type)
        {
            if (type == null)
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>;

            if (type == "AssetPurchaseTransaction")
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>;

            if (type == "AssetSaleTransaction")
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>;

            if (type == "CapitalAdditionTransaction")
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>;

            if (type == "CapitalDrawingTransaction")
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>;

            if (type == "ExpenseTransaction")
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>;

            if (type == "IncomeTransaction")
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>;

            if (type == "LiabilityIncreaseTransaction")
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>;

            if (type == "LiabilityDecreaseTransaction")
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>;

            return null;
        }

        public override IEntityViewModel<Transaction> CreateViewModelFromEntity(Transaction entity)
        {
            var overrides = new ResolverOverride[]{new ParameterOverride("entity", entity)};

            if (entity is IAssetPurchaseTransaction)
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "AssetPurchaseTransaction", overrides) as IEntityViewModel<Transaction>;
            if (entity is IAssetSaleTransaction)
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "AssetSaleTransaction", overrides) as IEntityViewModel<Transaction>;
            if (entity is ICapitalAdditionTransaction)
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "CapitalAdditionTransaction", overrides) as IEntityViewModel<Transaction>;
            if (entity is ICapitalDrawingTransaction)
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "CapitalDrawingTransaction", overrides) as IEntityViewModel<Transaction>;
            if (entity is IExpenseTransaction)
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "ExpenseTransaction", overrides) as IEntityViewModel<Transaction>;
            if (entity is IIncomeTransaction)
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "IncomeTransaction", overrides) as IEntityViewModel<Transaction>;
            if (entity is ILiabilityDecreaseTransaction)
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "LiabilityDecreaseTransaction", overrides) as IEntityViewModel<Transaction>;
            if (entity is ILiabilityIncreaseTransaction)
                return _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "LiabilityIncreaseTransaction", overrides) as IEntityViewModel<Transaction>;


            return null;
        }

    }
}
