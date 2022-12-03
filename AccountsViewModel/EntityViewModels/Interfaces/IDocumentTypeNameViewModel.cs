using AccountLib.Model;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface IDocumentTypeNameViewModel
        : IEntityViewModel<DocumentTypeName>
    {
        string Name { get; set; }
    }
}
