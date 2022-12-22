using AccountLib.Model.BusinessEntities;

namespace AccountsModelCore.Interfaces.Accounts
{
    public interface ILiabilityAccount : IAccount
    {
        int BusinessEntityId { get; set; }
        BusinessEntity Creditor { get; set; }
    }
}
