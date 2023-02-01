using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;
using AccountsModelCore.Classes;
using AccountsModelCore.Interfaces;
using AccountsModelCore.Interfaces.BusinessEntities;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.RegexFactories;
using AccountsViewModel.Services.Interfaces;

namespace AccountsViewModel.Services

{
    public class SourceDocumentTextReadService :
        ISourceDocumentTextReadService
    {
        private readonly IRegexFactory _regexFactory;

        public SourceDocumentTextReadService(
            IRegexFactory regexFactory
        )
        {
            _regexFactory = regexFactory;
        }

        public void GetDetailsFromText(ISourceDocumentCollectionAddEditViewModelState addEditViewModelState)
        {
            var sourcedocumenttext = addEditViewModelState.SourceDocumentText;
            var businessEntityViewModelCollection = (addEditViewModelState.BusinessEntityCollectionViewModel.CollectionViewState as ICollectionListViewModelState<BusinessEntity>).EntityCollection;
            addEditViewModelState.BusinessEntityCollectionViewModel.CollectionViewState.EntityViewModel = GetBusinessEntityFromText(sourcedocumenttext, businessEntityViewModelCollection);
        }

        private IEntityViewModel<BusinessEntity> GetBusinessEntityFromText(string Text, ICollection<IEntityViewModel<BusinessEntity>> businessEntityViewModelCollection)
        {
            foreach (IEntityViewModel<BusinessEntity> entity in businessEntityViewModelCollection)
            {
                var regex = _regexFactory.CreateRegex((entity as IBusinessEntityViewModel).BusinessEntityNameRegex);
                var match = regex.Match(Text);

                if (match.Success)
                {
                    return entity;
                }
            }

            return null;
        }

        public IBusinessEntitySourceDocumentType GetBusinessEntitySourceDocumentTypeFromText(string text, IBusinessEntity businessEntity)
        {
            foreach (BusinessEntitySourceDocumentType beType in businessEntity.BusinessEntitySourceDocumentTypes)
            {
                var regex = _regexFactory.CreateRegex(beType.DocumentTypeNameRegex);
                var match = regex.Match(text);

                if (match.Success)
                {
                    return beType;
                }
            }

            return null;
        }
    }
}
