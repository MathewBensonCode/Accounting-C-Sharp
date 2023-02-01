using System.Collections.Generic;
using AccountsModelCore.Classes;

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
