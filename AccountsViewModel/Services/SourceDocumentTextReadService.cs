using System.Globalization;
using AccountLib.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Services.Interfaces;
using AccountsViewModel.Factories.Interfaces.RegexFactories;
using AccountLib.Model.BusinessEntities;
using System.Text.RegularExpressions;
using AccountsViewModel.Factories.Interfaces;
using AccountLib.Model.Transactions;
using System;
using AccountLib.Model.Source_Documents;
using AccountLib.Interfaces.SourceDocuments;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.EntityViewModels;
using System.Collections.Generic;
using AccountsViewModel.EntityViewModels.Classes.Transactions;
using AccountsViewModel.EntityViewModels.Classes.SourceDocuments;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.Services

{
    public class SourceDocumentTextReadService :
        ISourceDocumentTextReadService
    {
        private readonly IRegexFactory _regexFactory;
        private readonly IViewModelFactory<Transaction> _transactionViewModelFactory;

        public SourceDocumentTextReadService(
            IRegexFactory regexFactory,
            IViewModelFactory<Transaction> transactionViewModelFactory
        )
        {
            _regexFactory = regexFactory;
            _transactionViewModelFactory = transactionViewModelFactory;
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

        private IBusinessEntitySourceDocumentType GetBusinessEntitySourceDocumentTypeFromText(string text, IBusinessEntity businessEntity)
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

        private void GetTransactionsFromText(string text, SourceDocumentViewModel sourceDocumentViewModel)
        {
            if (text == null)
            {
                throw new ArgumentNullException("source document text");
            }

            if (sourceDocumentViewModel == null)
            {
                throw new ArgumentNullException("SourceDocumentViewModel");
            }

            var businessEntitySourceDocumentType = sourceDocumentViewModel.BusinessEntitySourceDocumentTypeViewModel;

            Regex dateRegex = _regexFactory.CreateRegex(businessEntitySourceDocumentType.DateRegex);
            _ = _regexFactory.CreateRegex(businessEntitySourceDocumentType.ItemNameRegex);
            _ = _regexFactory.CreateRegex(businessEntitySourceDocumentType.ItemUnitCostRegex);
            _ = _regexFactory.CreateRegex(businessEntitySourceDocumentType.ItemQuantityRegex);
            Regex itemTotalCostRegex = _regexFactory.CreateRegex(businessEntitySourceDocumentType.ItemTotalCostRegex);
            _ = _regexFactory.CreateRegex(businessEntitySourceDocumentType.BusinessEntityItemReferenceRegex);
            Regex transactionRegex = _regexFactory.CreateRegex(businessEntitySourceDocumentType.TransactionRegex);

            Match match = dateRegex.Match(text);

            sourceDocumentViewModel.DocumentDate =
            DateTime.ParseExact(match.ToString(), @"d-M-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            var matches = transactionRegex.Matches(text);

            foreach (Match itemmatch in matches)
            {
                //TODO: Find Account Name From description text from item match
                TransactionViewModel transactionvm = _transactionViewModelFactory.CreateViewModelForNewEntity(null) as TransactionViewModel;
                var totalamountmatches = itemTotalCostRegex.Matches(itemmatch.Value);
                if (totalamountmatches.Count > 0)
                {
                    string amountstring = totalamountmatches.Count > 1 ? totalamountmatches[1].Value : totalamountmatches[0].Value;
                    _ = decimal.TryParse(amountstring, out decimal amountvalue);
                    transactionvm.Amount = amountvalue;
                }

                var sourceDocument = sourceDocumentViewModel.Entity;
                sourceDocument.Transactions.Add(transactionvm.Entity);
            }
        }

    }
}
