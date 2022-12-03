using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;

namespace AccountsModelCore.Interfaces.BusinessEntities
{
    public interface IRegisteredBusiness : IBusinessEntity
    {
        ICollection<BusinessEntity> RegisteredOwners { get; set; }
    }
}
