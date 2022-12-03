using AccountLib.Model.Accounts;

namespace AccountsViewModel.Xunit.Tests.Factories.Tests.UnityCommandViewModelFactoryTests
{
    public class AssetAccountCollectionCommandViewModelFactoryTests
        :CollectionCommandViewModelFactoryTests<AssetAccount>
    {
    }

    public class CapitalAccountCollectionCommandViewModelFactoryTests
        : CollectionCommandViewModelFactoryTests<CapitalAccount>
    {
    }

    public class CurrencyAccountCollectionCommandViewModelFactoryTests
        : CollectionCommandViewModelFactoryTests<CurrencyAccount>
    {
    }

    public class ExpenseAccountCollectionCommandViewModelFactoryTests
        : CollectionCommandViewModelFactoryTests<ExpenseAccount>
    {
    }

    public class IncomeAccountCollectionCommandViewModelFactoryTests
        : CollectionCommandViewModelFactoryTests<IncomeAccount>
    {
    }

    public class LiabilityAccountCollectionCommandViewModelFactoryTests
        : CollectionCommandViewModelFactoryTests<LiabilityAccount>
    {
    }

    public class TradeItemAssetAccountCollectionCommandViewModelFactoryTests
        : CollectionCommandViewModelFactoryTests<TradeItemAssetAccount>
    {
    }
}
