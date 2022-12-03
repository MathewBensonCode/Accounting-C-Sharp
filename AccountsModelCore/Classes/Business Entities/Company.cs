using AccountsModelCore.Interfaces.BusinessEntities;
using System.Collections.Generic;

namespace AccountLib.Model.BusinessEntities
{
    public class Company : BusinessEntity, ICompany
    {
        public ICollection<BusinessEntity> ShareHolders { get; set; }
        public ICollection<Person> Directors { get; set; }
    }
}
