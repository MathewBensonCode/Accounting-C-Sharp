using Accounts.Repositories;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;

namespace AccountsViewModel.Factories.Interfaces.CommandViewModelFactories
{
    public interface ICommandViewModelFactory<T> where T:class
    {
        ICommandViewModel CreateSelectAddViewCommand(ICollectionAddViewModelState<T> addviewstate, IEntityCollectionViewModel<T> collectionViewModel);
        ICommandViewModel CreateSelectEditViewCommand(ICollectionEditViewModelState<T> editviewstate, IEntityCollectionViewModel<T> collectionViewModel, ICollectionListViewModelState<T> listview);
        ICommandViewModel CreateDeleteCurrentCommand(ICollectionListViewModelState<T> listviewstate, IRepository<T> repository);
        ICommandViewModel CreateNextPageCommand(ICollectionListViewModelState<T> listview, IRepository<T> repository);
        ICommandViewModel CreatePreviousPageCommand(ICollectionListViewModelState<T> listview, IRepository<T> repository);
        ICommandViewModel CreateGoToBeginningCommmand(ICollectionListViewModelState<T> listview, IRepository<T> repository);
        ICommandViewModel CreateGoToEndCommand(ICollectionListViewModelState<T> listview, IRepository<T> repository);
        ICommandViewModel CreateSaveNewCommand(ICollectionAddViewModelState<T> addview, ICollectionListViewModelState<T> listview, IRepository<T> repository, IEntityCollectionViewModel<T> collectionviewmodel);
        ICommandViewModel CreateSaveEditCommand(ICollectionEditViewModelState<T> editview, ICollectionListViewModelState<T> listview, IRepository<T> repository, IEntityCollectionViewModel<T> collectionviewmodel) ;
        ICommandViewModel CreateCancelAddNewEditCommand(ICollectionListViewModelState<T> listview, IEntityCollectionViewModel<T> collectionviewmodel);
    }
}
