using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity.CommandViewModelFactories
{
    public class CollectionCommandViewModelFactory<T>
        : ICommandViewModelFactory<T>
        where T : class
    {
        private readonly IUnityContainer _container;

        public CollectionCommandViewModelFactory(IUnityContainer container)
        {
            _container = container;
        }
        public ICommandViewModel CreateCancelAddNewEditCommand(ICollectionListViewModelState<T> listview, IEntityCollectionViewModel<T> collectionviewmodel)
        {
            var commandname = "CancelAddNewEditCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
                new ResolverOverride[]
                {
                    new ParameterOverride("listViewState", listview),
                    new ParameterOverride("collectionViewModel", collectionviewmodel),
                }
                );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateDeleteCurrentCommand(ICollectionListViewModelState<T> listview, IRepository<T> repository)
        {
            var commandname = "DeleteCurrentCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
                new ResolverOverride[]
                {
                    new ParameterOverride("listViewState", listview),
                    new ParameterOverride("repository", repository),
                }
                );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateGoToBeginningCommmand(ICollectionListViewModelState<T> listviewstate, IRepository<T> repository)
        {
            var commandname = "GoToBeginningCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
               new ResolverOverride[]
               {
                    new ParameterOverride("listViewState", listviewstate),
                    new ParameterOverride("repository", repository),
               }
               );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateGoToEndCommand(ICollectionListViewModelState<T> listviewstate, IRepository<T> repository)
        {
            var commandname = "GoToEndCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
               new ResolverOverride[]
               {
                    new ParameterOverride("listViewState", listviewstate),
                    new ParameterOverride("repository", repository),
               }
               );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateNextPageCommand(ICollectionListViewModelState<T> listviewstate, IRepository<T> repository)
        {
            var commandname = "NextPageCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
               new ResolverOverride[]
               {
                    new ParameterOverride("listViewState", listviewstate),
                    new ParameterOverride("repository", repository),
               }
               );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreatePreviousPageCommand(ICollectionListViewModelState<T> listviewstate, IRepository<T> repository)
        {
            var commandname = "PreviousPageCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
               new ResolverOverride[]
               {
                    new ParameterOverride("listViewState", listviewstate),
                    new ParameterOverride("repository", repository),
               }
               );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateSaveEditCommand(ICollectionEditViewModelState<T> editview, ICollectionListViewModelState<T> listview, IRepository<T> repository, IEntityCollectionViewModel<T> collectionviewmodel)
        {

            var commandname = "SaveEditCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
                 new ResolverOverride[]
                 {
                    new ParameterOverride("editViewState", editview),
                    new ParameterOverride("listViewState", listview),
                    new ParameterOverride("collectionViewModel", collectionviewmodel),
                    new ParameterOverride("repository", repository)
                 }
                 );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateSaveNewCommand(ICollectionAddViewModelState<T> addview, ICollectionListViewModelState<T> listview, IRepository<T> repository, IEntityCollectionViewModel<T> collectionviewmodel)
        {
            var commandname = "SaveNewCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
                new ResolverOverride[]
                {
                    new ParameterOverride("addViewState", addview),
                    new ParameterOverride("listViewState", listview),
                    new ParameterOverride("collectionViewModel", collectionviewmodel),
                    new ParameterOverride("repository", repository)
                }
                );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateSelectAddViewCommand(ICollectionAddViewModelState<T> addviewstate, IEntityCollectionViewModel<T> collectionViewModel)
        {
            var commandname = "SelectAddViewCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
                new ResolverOverride[]
                {
                    new ParameterOverride("addState", addviewstate),
                    new ParameterOverride("collectionViewModel", collectionViewModel)
                }
                );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }

        public ICommandViewModel CreateSelectEditViewCommand(ICollectionEditViewModelState<T> editviewstate, IEntityCollectionViewModel<T> collectionViewModel, ICollectionListViewModelState<T> listview)
        {
            var commandname = "SelectEditViewCommand";
            var typestring = typeof(T).Name + commandname;
            var command = _container.Resolve(typeof(ICommand), typestring,
                new ResolverOverride[]
                {
                    new ParameterOverride("editViewState", editviewstate),
                    new ParameterOverride("collectionViewModel", collectionViewModel),
                    new ParameterOverride("listViewState", listview)
                }
                );
            var commandviewmodel = _container.Resolve(typeof(ICommandViewModel), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("command", command)
                });

            return commandviewmodel as ICommandViewModel;
        }
    }
}
