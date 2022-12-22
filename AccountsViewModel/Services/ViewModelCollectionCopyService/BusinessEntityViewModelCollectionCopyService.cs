using AccountLib.Model.BusinessEntities;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services.ViewModelCollectionCopyService
{
    public class BusinessEntityViewModelCollectionCopyService
    : ViewModelCollectionCopyService<BusinessEntity>
    {
        public BusinessEntityViewModelCollectionCopyService(
                IViewModelCopyService<BusinessEntity> viewmodelcopyservice,
                IViewModelFactory<BusinessEntity> viewmodelfactory
                )
           : base(viewmodelcopyservice, viewmodelfactory)
        {
        }
    }
}
