using AccountsModelCore.Classes.Accounts;

namespace AccountsViewModelTests.EntityCollectionViewModelTests
{
    public abstract class AccountCollectionViewModelTests :
        EntityCollectionViewModelTests<Account>
    {
    }

    public class AssetAccountCollectionViewModelTests :
        AccountCollectionViewModelTests
    {
    }

    public class CapitalAccountCollectionViewModelTests :
       AccountCollectionViewModelTests
    {
    }

    public class CurrencyAccountCollectionViewModelTests :
       AccountCollectionViewModelTests
    {
    }

    public class ExpenseAccountCollectionViewModelTests :
       AccountCollectionViewModelTests
    {
    }

    public class IncomeAccountCollectionViewModelTests :
       AccountCollectionViewModelTests
    {
    }

    public class LiabilityAccountCollectionViewModelTests :
       AccountCollectionViewModelTests
    {
    }

    public class TradeItemAssetAccountCollectionViewModelTests :
       AccountCollectionViewModelTests
    {
    }
}
