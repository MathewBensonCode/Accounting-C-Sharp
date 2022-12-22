using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Classes.Accounts;
using AccountsModelCore.Interfaces.Transactions;

namespace AccountsModelCore.Classes.Transactions
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
