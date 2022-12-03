using AccountLib.Model.Transactions;
using AccountsModelCore.Classes.DocumentImages;
using System;
using System.Collections.Generic;

namespace AccountLib.Interfaces.SourceDocuments
{
    public interface ISourceDocument
        : IDbModel
    {
        int BusinessEntitySourceDocumentTypeId { get; set; }

        DateTime? DocumentDate { get; set; }

        ICollection<Transaction> Transactions { get; set; }

        ICollection<DocumentImage> Images { get; set; }
    }
}
