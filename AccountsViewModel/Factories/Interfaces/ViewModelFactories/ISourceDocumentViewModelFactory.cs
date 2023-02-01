using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Interfaces.Images;
using AccountsModelCore.Interfaces.Transactions;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.ViewModelFactories
{
    public interface ISourceDocumentViewModelFactory :
        IViewModelFactory<SourceDocument>
    {
        ISourceDocumentViewModel CreateSourceDocumentViewModelForImage(IDocumentImage image);
        ISourceDocumentViewModel CreateSourceDocumentViewModelForTransaction(ITransaction transaction);
    }
}
