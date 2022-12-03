using AccountLib.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityRepositoryFactoryTests
{
    public class UnityAssetAccountsRepositoryFactoryTests
        : UnityRepositoryFactoryTests<AssetAccount>
    {
    }

    public class UnityCapitalAccountsRepositoryFactoryTests
        : UnityRepositoryFactoryTests<CapitalAccount>
    {
    }

    public class UnityCurrencyAccountsRepositoryFactoryTests
        : UnityRepositoryFactoryTests<CurrencyAccount>
    {
    }

    public class UnityExpenseAccountsRepositoryFactoryTests
        : UnityRepositoryFactoryTests<ExpenseAccount>
    {
    }

    public class UnityIncomeAccountsRepositoryFactoryTests
        : UnityRepositoryFactoryTests<IncomeAccount>
    {
    }

    public class UnityLiabilityAccountsRepositoryFactoryTests
        : UnityRepositoryFactoryTests<LiabilityAccount>
    {
    }

    public class UnityTradeItemAssetAccountsRepositoryFactoryTests
        : UnityRepositoryFactoryTests<TradeItemAssetAccount>
    {
    }
}
