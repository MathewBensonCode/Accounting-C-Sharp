using AccountLib.Model.Source_Documents;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class BusinessEntitySourceDocumentTypeViewModelCopyService :
        IViewModelCopyService<BusinessEntitySourceDocumentType>
    {
        public void CopyEntityViewModel(IEntityViewModel<BusinessEntitySourceDocumentType> copyfrom, IEntityViewModel<BusinessEntitySourceDocumentType> copyto)
        {
            var original = copyfrom as IBusinessEntitySourceDocumentTypeViewModel;
            var copy = copyto as IBusinessEntitySourceDocumentTypeViewModel;

            copy.BusinessEntityId = original.BusinessEntityId;
            copy.DocumentTypeNameId = original.DocumentTypeNameId;
            copy.DateRegex = original.DateRegex;
            copy.ItemNameRegex = original.ItemNameRegex;
            copy.ItemQuantityRegex = original.ItemQuantityRegex;
            copy.ItemUnitCostRegex = original.ItemUnitCostRegex;
            copy.BusinessEntityItemReferenceRegex = original.BusinessEntityItemReferenceRegex;
            copy.TransactionRegex = original.TransactionRegex;
            copy.DocumentTypeNameRegex = original.DocumentTypeNameRegex;

        }
    }
}
