using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Classes;
using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface IBusinessEntityViewModel
        : IEntityViewModel<BusinessEntity>
    {
        string Name { get; set; }
        int CountryId { get; set; }
        string BusinessEntityNameRegex { get; set; }

        IEntityCollectionViewModel<BusinessEntitySourceDocumentType> BusinessEntitySourceDocumentTypes { get; }
    }
}
