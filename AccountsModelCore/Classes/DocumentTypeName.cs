using System.Collections.Generic;
using AccountLib.Interfaces;
using AccountLib.Model.Source_Documents;

namespace AccountLib.Model
{
    public class DocumentTypeName :
        IDocumentTypeName
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BusinessEntitySourceDocumentType> BusinessEntitySourceDocumentTypes { get; set; }
    }
}
