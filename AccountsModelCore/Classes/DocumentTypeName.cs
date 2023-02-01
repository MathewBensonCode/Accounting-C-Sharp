using System.Collections.Generic;
using AccountsModelCore.Interfaces;

namespace AccountsModelCore.Classes
{
    public class DocumentTypeName :
        IDocumentTypeName
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BusinessEntitySourceDocumentType> BusinessEntitySourceDocumentTypes { get; set; }
    }
}
