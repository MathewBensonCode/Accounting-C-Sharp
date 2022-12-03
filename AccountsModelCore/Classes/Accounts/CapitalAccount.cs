using AccountLib.Interfaces.Accounts;
using AccountLib.Model.BusinessEntities;

namespace AccountLib.Model.Accounts
{
    public class CapitalAccount : Account, ICapitalAccount
    {
        public int BusinessEntityId { get; set; }
        public virtual BusinessEntity Owner { get; set; }
    }
}
