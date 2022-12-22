namespace AccountsModelCore.Interfaces
{
    public interface IBusinessEntitySourceDocumentType :
        IDbModel
    {
        int BusinessEntityId { get; set; }
        int DocumentTypeNameId { get; set; }

        string DocumentTypeNameRegex { get; set; }
        string DateRegex { get; set; }
        string ItemNameRegex { get; set; }
        string ItemUnitCostRegex { get; set; }
        string ItemQuantityRegex { get; set; }
        string ItemTotalCostRegex { get; set; }
        string BusinessEntityItemReferenceRegex { get; set; }
        string TransactionRegex { get; set; }
    }
}
