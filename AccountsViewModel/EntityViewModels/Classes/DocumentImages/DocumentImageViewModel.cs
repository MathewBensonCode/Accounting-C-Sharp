using AccountLib.Interfaces.Images;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using System.Collections.Generic;
using AccountsModelCore.Classes.DocumentImages;

namespace AccountsViewModel.EntityViewModels.Classes.DocumentImages
{
    public class DocumentImageViewModel : EntityViewModel<DocumentImage>, IDocumentImageViewModel
    {
        private readonly ISourceDocumentViewModelFactory _sourceDocumentViewModelFactory;

        public DocumentImageViewModel(
            IDocumentImage entity,
            ISourceDocumentViewModelFactory sourceDocumentViewModelFactory,
            IImageViewModelCommandFactory commandfactory,
            IDictionary<string, List<string>> errors
            )
        : base(entity as DocumentImage, errors)
        {
            _sourceDocumentViewModelFactory = sourceDocumentViewModelFactory;
            ScanImageCommand = commandfactory.CreateScanImageCommand(this);
            GetImageFromFileCommand = commandfactory.CreateGetImageFromFileCommand(this);
            GetTextFromImageCommand = commandfactory.CreateGetTextFromImageCommand(this);
        }

        private IDocumentImage Documentimage => Entity;

        public string Path
        {
            get => Documentimage.Path;

            set
            {
                Documentimage.Path = value;
                RaisePropertyChanged();
            }
        }

        public int SourceDocumentId
        {
            get => Documentimage.SourceDocumentId;

            set
            {
                Documentimage.SourceDocumentId = value;
                RaisePropertyChanged();
            }
        }

        public ISourceDocumentViewModel SourceDocumentViewModel => _sourceDocumentViewModelFactory.CreateSourceDocumentViewModelForImage(Documentimage);

        public string SourceDocumentText
        {
            get => Documentimage.SourceDocumentText;
            set
            {
                Documentimage.SourceDocumentText = value;
                RaisePropertyChanged("SourceDocumentText");
            }

        }

        public ICommandViewModel ScanImageCommand
        {
            get; protected set;
        }

        public ICommandViewModel GetImageFromFileCommand
        {
            get; protected set;
        }

        public ICommandViewModel GetTextFromImageCommand
        {
            get; protected set;
        }
    }
}
