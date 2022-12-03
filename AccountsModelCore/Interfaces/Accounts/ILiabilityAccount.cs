using AccountLib.Model.BusinessEntities;

namespace AccountLib.Interfaces.Accounts
{
    public interface ILiabilityAccount : IAccount
    {
        int BusinessEntityId { get; set; }
        BusinessEntity Creditor { get; set;}
    }
}
