using AccountLib.Interfaces.Accounts;
using AccountLib.Model.BusinessEntities;

namespace AccountLib.Model.Accounts
{
    public class LiabilityAccount : Account, ILiabilityAccount
    {
        public int BusinessEntityId { get; set; }
        public virtual BusinessEntity Creditor { get; set; }
    }
}
