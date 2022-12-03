using AccountLib.Model.SourceDocuments;
using AccountLib.Interfaces.Images;
using AccountLib.Interfaces.Transactions;
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
