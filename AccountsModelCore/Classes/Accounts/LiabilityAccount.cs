using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsModelCore.Classes.Accounts
{
    public class LiabilityAccount : Account, ILiabilityAccount
    {
        public int BusinessEntityId { get; set; }
        public virtual BusinessEntity Creditor { get; set; }
    }
}
