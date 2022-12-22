using System.Windows.Input;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.CommandViewModels.NavigationCommands;
using Unity;

namespace AccountsViewModel.Services
{
    public static class RegisterCollectionViewModelCommandsService
    {
        public static void Register<T>(IUnityContainer container) where T : class
        {
            string typename = typeof(T).Name.ToString();

            _ = container.RegisterType(typeof(ICommand), typeof(CancelAddNewAndEditCommand<T>), typename + "CancelAddNewEditCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(DeleteCurrentEntityFromCollectionCommand<T>), typename + "DeleteCurrentCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(SaveEditedEntityCommand<T>), typename + "SaveEditCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(SaveNewToRepositoryCommand<T>), typename + "SaveNewCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(SelectAddViewCommand<T>), typename + "SelectAddViewCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(SelectEditViewCommand<T>), typename + "SelectEditViewCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(GoToBeginningCollectionCommand<T>), typename + "GoToBeginningCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(GoToEndCollectionCommand<T>), typename + "GoToEndCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(NextPageCollectionCommand<T>), typename + "NextPageCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(PreviousPageCollectionCommand<T>), typename + "PreviousPageCommand");

        }
    }
}
