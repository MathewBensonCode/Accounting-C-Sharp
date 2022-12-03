using AccountLib.Model.Accounts;
using Accounts.Repositories;
using AccountLib.Interfaces.Accounts;
using AccountLib.Interfaces.Transactions;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using Unity;
using Unity.Resolution;
using AccountsViewModel.Entity.Interfaces;

namespace AccountsViewModel.Factories.Unity.ViewModelFactories
{
    public class AccountUnityViewModelFactory
        : UnityViewModelFactory<Account>, IAccountViewModelFactory
    {
        private readonly IAccountRepository _repository;

        public AccountUnityViewModelFactory(
            IRepository<Account> repository,
            IUnityContainer container)
            : base(container)
        {
            _repository = repository as IAccountRepository;
        }

        public IAccountViewModel GetDebitAccountViewModelForTransaction(ITransaction transaction)
        {
            var account = _repository.Find(transaction.DebitAccountId);
            IAccountViewModel accountvm = null;

            if (transaction is IAssetPurchaseTransaction)
                accountvm = ResolveAccountType<AssetAccount>(account);

            if (transaction is IAssetSaleTransaction)
                accountvm = ResolveAccountType<CurrencyAccount>(account);

            if (transaction is ICapitalAdditionTransaction)
                accountvm = ResolveAccountType<CurrencyAccount>(account);

            if (transaction is ICapitalDrawingTransaction)
                accountvm = ResolveAccountType<CapitalAccount>(account);

            if (transaction is IExpenseTransaction)
                accountvm = ResolveAccountType<ExpenseAccount>(account);

            if (transaction is IIncomeTransaction)
                accountvm = ResolveAccountType<CurrencyAccount>(account);

            if (transaction is ILiabilityDecreaseTransaction)
                accountvm = ResolveAccountType<LiabilityAccount>(account);

            if (transaction is ILiabilityIncreaseTransaction)
                accountvm = ResolveAccountType<CurrencyAccount>(account);

            return accountvm;

        }

        public IAccountViewModel GetCreditAccountViewModelForTransaction(ITransaction transaction)
        {
            var account = _repository.Find(transaction.CreditAccountId);
            IAccountViewModel accountvm = null;

            if (transaction is IAssetPurchaseTransaction)
                accountvm = ResolveAccountType<CurrencyAccount>(account);

            if (transaction is IAssetSaleTransaction)
                accountvm = ResolveAccountType<AssetAccount>(account);

            if (transaction is ICapitalAdditionTransaction)
                accountvm = ResolveAccountType<CapitalAccount>(account);

            if (transaction is ICapitalDrawingTransaction)
                accountvm = ResolveAccountType<CurrencyAccount>(account);

            if (transaction is IExpenseTransaction)
                accountvm = ResolveAccountType<CurrencyAccount>(account);

            if (transaction is IIncomeTransaction)
                accountvm = ResolveAccountType<IncomeAccount>(account);

            if (transaction is ILiabilityDecreaseTransaction)
                accountvm = ResolveAccountType<CurrencyAccount>(account);

            if (transaction is ILiabilityIncreaseTransaction)
                accountvm = ResolveAccountType<LiabilityAccount>(account);
            return accountvm;
        }

        IAccountViewModel ResolveAccountType<T>(IAccount account) where T : Account
        {
            return _unityContainer.Resolve(typeof(IEntityViewModel<T>), null, new ResolverOverride[] { new ParameterOverride("entity", account) }) as IAccountViewModel;
        }

    }
}
