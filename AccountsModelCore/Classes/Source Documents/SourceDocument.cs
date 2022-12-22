using System;
using System.Collections.Generic;
using AccountsModelCore.Classes;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Classes.Transactions;
using AccountsModelCore.Interfaces;
using AccountsModelCore.Interfaces.SourceDocuments;

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
