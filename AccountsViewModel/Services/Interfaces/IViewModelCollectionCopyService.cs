using AccountsViewModel.CollectionViewModels.Interfaces;

namespace AccountsViewModel.Services.Interfaces
{
    public interface IViewModelCollectionCopyService<T>
        where T:class
    {
        void CopyCollection(IEntityCollectionViewModel<T> copyfrom, IEntityCollectionViewModel<T> copyto);
    }
}
