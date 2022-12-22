using AccountsModelCore.Classes;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface IBusinessEntitySourceDocumentTypeViewModel :
        IEntityViewModel<BusinessEntitySourceDocumentType>
    {
        int BusinessEntityId { get; set; }
        IBusinessEntityViewModel BusinessEntity { get; }

        int DocumentTypeNameId { get; set; }
        IDocumentTypeNameViewModel DocumentTypeName { get; }

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
