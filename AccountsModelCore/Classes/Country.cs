using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Interfaces;
using System.Collections.Generic;

namespace AccountsModelCore.Classes
{
    public class Country : ICountry, IDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso { get; set; }
        public string Iso3 { get; set; }
        public int NumCode { get; set; }

        public virtual ICollection<BusinessEntity> BusinessEntities { get; set; }
    }
}
