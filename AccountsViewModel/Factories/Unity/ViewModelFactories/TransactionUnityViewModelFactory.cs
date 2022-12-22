using System;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.EntityViewModels.Interfaces;
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
            return type == null
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>
                : type == "AssetPurchaseTransaction"
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>
                : type == "AssetSaleTransaction"
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>
                : type == "CapitalAdditionTransaction"
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>
                : type == "CapitalDrawingTransaction"
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>
                : type == "ExpenseTransaction"
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>
                : type == "IncomeTransaction"
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>
                : type == "LiabilityIncreaseTransaction"
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>
                : type == "LiabilityDecreaseTransaction"
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), type) as IEntityViewModel<Transaction>
                : null;
        }

        public override IEntityViewModel<Transaction> CreateViewModelFromEntity(Transaction entity)
        {
            var overrides = new ResolverOverride[] { new ParameterOverride("entity", entity) };

            return entity is IAssetPurchaseTransaction
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "AssetPurchaseTransaction", overrides) as IEntityViewModel<Transaction>
                : entity is IAssetSaleTransaction
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "AssetSaleTransaction", overrides) as IEntityViewModel<Transaction>
                : entity is ICapitalAdditionTransaction
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "CapitalAdditionTransaction", overrides) as IEntityViewModel<Transaction>
                : entity is ICapitalDrawingTransaction
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "CapitalDrawingTransaction", overrides) as IEntityViewModel<Transaction>
                : entity is IExpenseTransaction
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "ExpenseTransaction", overrides) as IEntityViewModel<Transaction>
                : entity is IIncomeTransaction
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "IncomeTransaction", overrides) as IEntityViewModel<Transaction>
                : entity is ILiabilityDecreaseTransaction
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "LiabilityDecreaseTransaction", overrides) as IEntityViewModel<Transaction>
                : entity is ILiabilityIncreaseTransaction
                ? _unityContainer.Resolve(typeof(IEntityViewModel<Transaction>), "LiabilityIncreaseTransaction", overrides) as IEntityViewModel<Transaction>
                : null;
        }

    }
}
