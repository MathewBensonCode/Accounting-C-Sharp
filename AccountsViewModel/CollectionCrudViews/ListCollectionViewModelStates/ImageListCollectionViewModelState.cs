using System.Collections.Generic;
using Accounts.Repositories;
using AccountsModelCore.Classes.DocumentImages;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
{
    public class ImageListCollectionViewModelState
        : EntityListCollectionViewModelState<DocumentImage>
    {
        public ImageListCollectionViewModelState(
            IRepository<DocumentImage> repository,
            ICollection<IEntityViewModel<DocumentImage>> collection,
            ICommandViewModelFactory<DocumentImage> commandfactory,
            ICollectionCrudAddViewStateFactory<DocumentImage> addStateFactory,
            ICollectionCrudEditViewStateFactory<DocumentImage> editStateFactory,
            IEntityCollectionViewModel<DocumentImage> entityCollectionViewModel,
            IViewModelCollectionCreationService<DocumentImage> vmCreationService)
            : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }
    }
}
