using System.Collections.Generic;
using AccountLib.Model.SourceDocuments;
using Accounts.Repositories;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.CollectionCrudViews
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
