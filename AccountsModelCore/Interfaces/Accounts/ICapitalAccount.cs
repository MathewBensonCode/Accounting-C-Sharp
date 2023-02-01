using AccountLib.Model.BusinessEntities;

namespace AccountsModelCore.Interfaces.Accounts
{
    public interface ICapitalAccount : IAccount
    {
        int BusinessEntityId { get; set; }
        BusinessEntity Owner { get; set; }
    }
}
