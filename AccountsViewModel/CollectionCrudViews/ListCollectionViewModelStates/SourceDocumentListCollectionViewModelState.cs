using System.Collections.Generic;
using AccountLib.Model.SourceDocuments;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Repositories.Interfaces;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews.ListCollectionViewModelStates
{
    public class SourceDocumentListCollectionViewModelState
        : EntityListCollectionViewModelState<SourceDocument>
    {
        public SourceDocumentListCollectionViewModelState(
            IRepository<SourceDocument> repository,
            ICollection<IEntityViewModel<SourceDocument>> collection,
            ICommandViewModelFactory<SourceDocument> commandfactory,
            ICollectionCrudAddViewStateFactory<SourceDocument> addStateFactory,
            ICollectionCrudEditViewStateFactory<SourceDocument> editStateFactory,
            IEntityCollectionViewModel<SourceDocument> entityCollectionViewModel,
            IViewModelCollectionCreationService<SourceDocument> vmCreationService)
            : base(repository, collection, commandfactory, addStateFactory, editStateFactory, entityCollectionViewModel, vmCreationService)
        {
        }
    }
}
