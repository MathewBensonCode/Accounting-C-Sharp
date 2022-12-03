using AccountLib.Model.BusinessEntities;

namespace AccountLib.Interfaces.Accounts
{
    public interface ICapitalAccount: IAccount
    {
        int BusinessEntityId { get; set; }
        BusinessEntity Owner { get; set; }
    }
}
