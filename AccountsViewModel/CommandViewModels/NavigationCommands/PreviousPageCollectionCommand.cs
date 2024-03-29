﻿using AccountsViewModel.CollectionCrudViews.Interfaces;
using Prism.Commands;

namespace AccountsViewModel.CommandViewModels.NavigationCommands
{
    public class PreviousPageCollectionCommand<T> :
        DelegateCommand where T : class
    {
        public PreviousPageCollectionCommand(
            ICollectionListViewModelState<T> listViewState
            ) :
            base(
                () =>
                {
                    listViewState.CurrentPage--;
                },

                () =>
                {
                    return listViewState.CurrentPage > 1;
                }
                )
        {

        }
    }
}
