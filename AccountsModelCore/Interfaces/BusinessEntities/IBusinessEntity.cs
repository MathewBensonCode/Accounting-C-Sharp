using System.Collections.Generic;
using AccountLib.Interfaces;
using AccountLib.Model.Source_Documents;

namespace AccountsModelCore.Interfaces.BusinessEntities
{
    public interface IBusinessEntity
        : IDbModel
    {
        string Name { get; set; }

        int CountryId { get; set; }

        string BusinessEntityNameRegex { get; set; }

        ICollection<BusinessEntitySourceDocumentType> BusinessEntitySourceDocumentTypes { get; set; }

    }
}
