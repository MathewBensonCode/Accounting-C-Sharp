using AccountLib.Interfaces.Transactions;
using AccountLib.Model.Accounts;
using AccountLib.Model.SourceDocuments;

namespace AccountLib.Model.Transactions
{
    public class Transaction : ITransaction
    {
        public int Id { get; set; }

        public int DebitAccountId { get; set; }//foreign key to Account table representing debits
        public virtual Account DebitAccount { get; set; }

        public int CreditAccountId { get; set; }//foreign key to Account table representing credits
        public virtual Account CreditAccount { get; set; }

        public int SourceDocumentId { get; set; }//foreign key to SourceDocumentScan
        public virtual SourceDocument SourceDocument { get; set; }

        public decimal Amount { get; set; }
    }
}
