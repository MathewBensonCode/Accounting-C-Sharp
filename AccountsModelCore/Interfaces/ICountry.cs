using AccountLib.Model.BusinessEntities;
using System.Collections.Generic;

namespace AccountsModelCore.Interfaces
{
    public interface ICountry
    {
        string Name { get; set; }
        string Iso { get; set; }
        string Iso3 { get; set; }
        int NumCode { get; set; }

        ICollection<BusinessEntity> BusinessEntities { get; set; }
    }
}
