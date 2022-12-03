using AccountLib.Model.BusinessEntities;
using AccountLib.Model.Source_Documents;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCopyService
{
    public class BusinessEntityViewModelCopyService
        : IViewModelCopyService<BusinessEntity>
    {
        private readonly IViewModelCollectionCopyService<BusinessEntitySourceDocumentType> _businessEntitySourceDocumentTypesCollectionCopyService;

        public BusinessEntityViewModelCopyService(
            IViewModelCollectionCopyService<BusinessEntitySourceDocumentType> businessEntitySourceDocumentTypesCollectionCopyService
            )
        {
            this._businessEntitySourceDocumentTypesCollectionCopyService = businessEntitySourceDocumentTypesCollectionCopyService;
        }
        public void CopyEntityViewModel(
            EntityViewModels.IEntityViewModel<BusinessEntity> copyfrom, 
            EntityViewModels.IEntityViewModel<BusinessEntity> copyto)
        {
            var orig = copyfrom as IBusinessEntityViewModel;
            var copy = copyto as IBusinessEntityViewModel;


            copy.Name = orig.Name;
            copy.CountryId = orig.CountryId;
            copy.BusinessEntityNameRegex = orig.BusinessEntityNameRegex;
          

            if (orig is IPersonBusinessEntityViewModel)
            {
                var origperson = orig as IPersonBusinessEntityViewModel;
                var copyperson = copy as IPersonBusinessEntityViewModel;

                copyperson.FirstName = origperson.FirstName;
                copyperson.LastName = origperson.LastName;
            }

            _businessEntitySourceDocumentTypesCollectionCopyService.CopyCollection(orig.BusinessEntitySourceDocumentTypes, copy.BusinessEntitySourceDocumentTypes);
        }
    }
}
