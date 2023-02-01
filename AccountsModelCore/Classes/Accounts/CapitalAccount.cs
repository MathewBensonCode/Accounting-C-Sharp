using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Interfaces.Accounts;

namespace AccountsModelCore.Classes.Accounts
{
    public class CapitalAccount : Account, ICapitalAccount
    {
        public int BusinessEntityId { get; set; }
        public virtual BusinessEntity Owner { get; set; }
    }
}
