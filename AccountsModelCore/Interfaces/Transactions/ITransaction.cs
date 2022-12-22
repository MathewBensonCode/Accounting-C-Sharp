namespace AccountsModelCore.Interfaces.Transactions
{
    public interface ITransaction
       : IDbModel
    {
        int DebitAccountId { get; set; }

        int CreditAccountId { get; set; }

        int SourceDocumentId { get; set; }

        decimal Amount { get; set; }
    }
}
