using System.Collections.Generic;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountLib.Model.BusinessEntities
{
    public class RegisteredBusiness : BusinessEntity, IRegisteredBusiness
    {
        public ICollection<BusinessEntity> RegisteredOwners { get; set; }
    }
}
