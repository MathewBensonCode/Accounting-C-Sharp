using AccountLib.Model.BusinessEntities;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsModelCore.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface IBusinessEntityViewModelFactory :
        IViewModelFactory<BusinessEntity>
    {
        IBusinessEntityViewModel GetBusinessEntityViewModelForBusinessEntitySourceDocumentType(IBusinessEntitySourceDocumentType businessEntitySourceDocumentType);
    }
}
