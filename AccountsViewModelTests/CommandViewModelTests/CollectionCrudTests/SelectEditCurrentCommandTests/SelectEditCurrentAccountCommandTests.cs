using AccountLib.Model.Accounts;
using AccountsViewModel.Xunit.Tests.CommandViewModelTests.CollectionCrudTests.SaveEditToCollectionCommandTests;

namespace AccountsViewModel.Xunit.Tests.CommandViewModelTests.CollectionCrudTests.SelectEditCurrentCommandTests
{
    public class SaveEditAssetAccountToRepositoryViewModelTests :
      SaveEditToRepositoryCommandTests<AssetAccount>
    {
    }

    public class SaveNewCapitalAccountToRepositoryViewModelTests :
        SaveEditToRepositoryCommandTests<CapitalAccount>
    {
    }

    public class SaveNewCurrencyAccountToRepositoryViewModelTests :
        SaveEditToRepositoryCommandTests<CurrencyAccount>
    {
    }

    public class SaveNewExpenseAccountToRepositoryViewModelTests :
        SaveEditToRepositoryCommandTests<ExpenseAccount>
    {
    }

    public class SaveNewIncomeAccountToRepositoryViewModelTests :
        SaveEditToRepositoryCommandTests<IncomeAccount>
    {
    }

    public class SaveNewLiabilityAccountToRepositoryViewModelTests :
        SaveEditToRepositoryCommandTests<LiabilityAccount>
    {
    }

    public class SaveNewTradeItemAssetAccountToRepositoryViewModelTests :
        SaveEditToRepositoryCommandTests<TradeItemAssetAccount>
    {
    }
}
