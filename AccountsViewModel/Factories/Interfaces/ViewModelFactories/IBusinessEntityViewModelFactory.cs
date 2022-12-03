using AccountLib.Model.BusinessEntities;
using AccountLib.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface IBusinessEntityViewModelFactory :
        IViewModelFactory<BusinessEntity>
    {
        IBusinessEntityViewModel GetBusinessEntityViewModelForBusinessEntitySourceDocumentType(IBusinessEntitySourceDocumentType businessEntitySourceDocumentType);
    }
}
