using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Interfaces;

namespace AccountsModelCore.Classes
{
    public class BusinessEntitySourceDocumentType :
        IBusinessEntitySourceDocumentType, IDbModel
    {
        public int Id { get; set; }

        public int BusinessEntityId { get; set; }
        public virtual BusinessEntity BusinessEntity { get; set; }

        public int DocumentTypeNameId { get; set; }
        public virtual DocumentTypeName DocumentTypeName { get; set; }

        public string DateRegex { get; set; }
        public string ItemNameRegex { get; set; }
        public string ItemUnitCostRegex { get; set; }
        public string ItemQuantityRegex { get; set; }
        public string ItemTotalCostRegex { get; set; }
        public string BusinessEntityItemReferenceRegex { get; set; }
        public string TransactionRegex { get; set; }
        public string DocumentTypeNameRegex { get; set; }
    }
}
