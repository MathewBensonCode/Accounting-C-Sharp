using System.Collections.Generic;
using AccountLib.Model.Source_Documents;
using AccountLib.Interfaces;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;

namespace AccountsViewModel.EntityViewModels.Classes.BusinessEntitySourceDocumentTypes
{
    public class BusinessEntitySourceDocumentTypeViewModel :
        EntityViewModel<BusinessEntitySourceDocumentType>, IBusinessEntitySourceDocumentTypeViewModel
    {
        private readonly IBusinessEntityViewModelFactory _businessEntityViewModelFactory;
        private readonly IDocumentTypeNameViewModelFactory _documentTypeNameViewModelFactory;

        public BusinessEntitySourceDocumentTypeViewModel(
            IBusinessEntitySourceDocumentType entity,
            IDictionary<string, List<string>> errors,
            IBusinessEntityViewModelFactory businessEntityViewModelFactory,
            IDocumentTypeNameViewModelFactory documentTypeNameViewModelFactory)
            : base(entity as BusinessEntitySourceDocumentType, errors)
        {
            _businessEntityViewModelFactory = businessEntityViewModelFactory;
            _documentTypeNameViewModelFactory = documentTypeNameViewModelFactory;
        }

        private IBusinessEntitySourceDocumentType BusinessEntitySourceDocumentType => Entity;

        public int BusinessEntityId
        {
            get => BusinessEntitySourceDocumentType.BusinessEntityId;
            set
            {
                BusinessEntitySourceDocumentType.BusinessEntityId = value;
                RaisePropertyChanged();
            }
        }

        public int DocumentTypeNameId
        {
            get => BusinessEntitySourceDocumentType.DocumentTypeNameId;
            set
            {
                if (value != BusinessEntitySourceDocumentType.DocumentTypeNameId)
                {
                    BusinessEntitySourceDocumentType.DocumentTypeNameId = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("DocumentTypeName");
                }
            }
        }

        public string DateRegex
        {
            get => BusinessEntitySourceDocumentType.DateRegex;
            set
            {
                BusinessEntitySourceDocumentType.DateRegex = value;
                RaisePropertyChanged();
            }
        }

        public string ItemNameRegex
        {
            get => BusinessEntitySourceDocumentType.ItemNameRegex;
            set
            {
                BusinessEntitySourceDocumentType.ItemNameRegex = value;
                RaisePropertyChanged();
            }
        }

        public string ItemUnitCostRegex
        {
            get => BusinessEntitySourceDocumentType.ItemUnitCostRegex;
            set
            {
                BusinessEntitySourceDocumentType.ItemUnitCostRegex = value;
                RaisePropertyChanged();
            }
        }

        public string ItemQuantityRegex
        {
            get => BusinessEntitySourceDocumentType.ItemQuantityRegex;
            set
            {
                BusinessEntitySourceDocumentType.ItemQuantityRegex = value;
                RaisePropertyChanged();
            }
        }

        public string BusinessEntityItemReferenceRegex
        {
            get => BusinessEntitySourceDocumentType.BusinessEntityItemReferenceRegex;
            set
            {
                BusinessEntitySourceDocumentType.BusinessEntityItemReferenceRegex = value;
                RaisePropertyChanged();
            }
        }

        public string TransactionRegex
        {
            get => BusinessEntitySourceDocumentType.TransactionRegex;
            set
            {
                BusinessEntitySourceDocumentType.TransactionRegex = value;
                RaisePropertyChanged();
            }
        }

        public IBusinessEntityViewModel BusinessEntity => _businessEntityViewModelFactory.GetBusinessEntityViewModelForBusinessEntitySourceDocumentType(BusinessEntitySourceDocumentType);

        public IDocumentTypeNameViewModel DocumentTypeName => _documentTypeNameViewModelFactory.GetDocumentTypeNameViewModelForBusinessEntitySourceDocumentType(BusinessEntitySourceDocumentType) as IDocumentTypeNameViewModel;

        public string ItemTotalCostRegex
        {
            get => BusinessEntitySourceDocumentType.ItemTotalCostRegex;

            set
            {
                BusinessEntitySourceDocumentType.ItemTotalCostRegex = value;
                RaisePropertyChanged();
            }
        }

        public string DocumentTypeNameRegex
        {
            get => BusinessEntitySourceDocumentType.DocumentTypeNameRegex;

            set
            {
                BusinessEntitySourceDocumentType.DocumentTypeNameRegex = value;
                RaisePropertyChanged();
            }
        }
    }
}
