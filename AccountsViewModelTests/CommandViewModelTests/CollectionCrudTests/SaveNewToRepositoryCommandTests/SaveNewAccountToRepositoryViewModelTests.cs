using AccountsModelCore.Classes.Accounts;

namespace AccountsViewModelTests.CommandViewModelTests.CollectionCrudTests.SaveNewToRepositoryCommandTests
{
    public class SaveNewAssetAccountToRepositoryViewModelTests :
        SaveNewEntityToRepositoryCommandTests<AssetAccount>
    {
    }

    public class SaveNewCapitalAccountToRepositoryViewModelTests :
        SaveNewEntityToRepositoryCommandTests<CapitalAccount>
    {
    }

    public class SaveNewCurrencyAccountToRepositoryViewModelTests :
        SaveNewEntityToRepositoryCommandTests<CurrencyAccount>
    {
    }

    public class SaveNewExpenseAccountToRepositoryViewModelTests :
        SaveNewEntityToRepositoryCommandTests<ExpenseAccount>
    {
    }

    public class SaveNewIncomeAccountToRepositoryViewModelTests :
        SaveNewEntityToRepositoryCommandTests<IncomeAccount>
    {
    }

    public class SaveNewLiabilityAccountToRepositoryViewModelTests :
        SaveNewEntityToRepositoryCommandTests<LiabilityAccount>
    {
    }

    public class SaveNewTradeItemAssetAccountToRepositoryViewModelTests :
        SaveNewEntityToRepositoryCommandTests<TradeItemAssetAccount>
    {
    }
}
