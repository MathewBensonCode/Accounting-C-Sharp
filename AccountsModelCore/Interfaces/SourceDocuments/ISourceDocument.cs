using System;
using System.Collections.Generic;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Classes.Transactions;

namespace AccountsModelCore.Interfaces.SourceDocuments
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
