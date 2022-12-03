using System.Windows.Input;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.CommandViewModels.NavigationCommands;
using Unity;

namespace AccountsViewModel.Services
{
    public static class RegisterCollectionViewModelCommandsService
    {
        public static void Register<T>(IUnityContainer container) where T:class
        {
            string typename = typeof(T).Name.ToString();

            container.RegisterType(typeof(ICommand), typeof(CancelAddNewAndEditCommand<T>), typename + "CancelAddNewEditCommand");
            container.RegisterType(typeof(ICommand), typeof(DeleteCurrentEntityFromCollectionCommand<T>), typename + "DeleteCurrentCommand");
            container.RegisterType(typeof(ICommand), typeof(SaveEditedEntityCommand<T>), typename + "SaveEditCommand");
            container.RegisterType(typeof(ICommand), typeof(SaveNewToRepositoryCommand<T>), typename + "SaveNewCommand");
            container.RegisterType(typeof(ICommand), typeof(SelectAddViewCommand<T>), typename + "SelectAddViewCommand");
            container.RegisterType(typeof(ICommand), typeof(SelectEditViewCommand<T>), typename + "SelectEditViewCommand");
            container.RegisterType(typeof(ICommand), typeof(GoToBeginningCollectionCommand<T>), typename + "GoToBeginningCommand");
            container.RegisterType(typeof(ICommand), typeof(GoToEndCollectionCommand<T>), typename + "GoToEndCommand");
            container.RegisterType(typeof(ICommand), typeof(NextPageCollectionCommand<T>), typename + "NextPageCommand");
            container.RegisterType(typeof(ICommand), typeof(PreviousPageCollectionCommand<T>), typename + "PreviousPageCommand");

        }
    }
}
