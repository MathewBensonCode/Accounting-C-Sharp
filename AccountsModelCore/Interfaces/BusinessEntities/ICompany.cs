using AccountLib.Model.BusinessEntities;
using System.Collections.Generic;

namespace AccountsModelCore.Interfaces.BusinessEntities
{
    public interface ICompany : IBusinessEntity
    {
        ICollection<BusinessEntity> ShareHolders { get; set; }
        ICollection<Person> Directors { get; set; }
    }
}
