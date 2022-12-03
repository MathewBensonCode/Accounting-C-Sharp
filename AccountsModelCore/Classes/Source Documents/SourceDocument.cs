using AccountLib.Interfaces;
using AccountLib.Interfaces.SourceDocuments;
using AccountLib.Model.Source_Documents;
using AccountLib.Model.Transactions;
using AccountsModelCore.Classes.DocumentImages;
using System;
using System.Collections.Generic;

namespace AccountLib.Model.SourceDocuments

{
    public class SourceDocument : ISourceDocument, IDbModel
    {
        public int Id { get; set; }

        public virtual ICollection<DocumentImage> Images { get; set; }

        public int BusinessEntitySourceDocumentTypeId { get; set; }//foreign key to BusinessEntity
        public virtual BusinessEntitySourceDocumentType BusinessEntitySourceDocumentType { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public DateTime? DocumentDate { get; set; }
    }
}
