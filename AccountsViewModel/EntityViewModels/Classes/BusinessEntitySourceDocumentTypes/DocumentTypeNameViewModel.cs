using AccountLib.Model;
using AccountLib.Interfaces;
using System.Collections.Generic;
using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.EntityViewModels.Classes.BusinessEntitySourceDocumentTypes
{
    public class DocumentTypeNameViewModel :
        EntityViewModel<DocumentTypeName>, IDocumentTypeNameViewModel
    {

        public DocumentTypeNameViewModel(
            IDocumentTypeName entity,
            IDictionary<string, List<string>> errors
            ) : base(entity as DocumentTypeName, errors)
        {
        }

        protected IDocumentTypeName DocumentTypeName => Entity;

        public string Name
        {
            get => DocumentTypeName.Name;
            set
            {
                DocumentTypeName.Name = value;
                RaisePropertyChanged();
            }
        }
    }
}
