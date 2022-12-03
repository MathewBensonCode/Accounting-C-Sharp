using AccountLib.Interfaces;
using AccountLib.Model.BusinessEntities;
using System.Collections.Generic;

namespace AccountLib.Model
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
