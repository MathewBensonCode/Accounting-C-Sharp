using System.Collections.Generic;
using AccountLib.Interfaces;
using AccountLib.Model.Source_Documents;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountLib.Model.BusinessEntities
{
    public class BusinessEntity : IBusinessEntity, IDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }//foreign key to Country
        public virtual Country Country { get; set; }

        public virtual ICollection<BusinessEntitySourceDocumentType> BusinessEntitySourceDocumentTypes { get; set; }
        public string BusinessEntityNameRegex { get; set; }
    }
}

