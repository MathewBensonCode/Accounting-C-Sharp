using AccountLib.Model.SourceDocuments;
using AccountsModelCore.Interfaces;
using AccountsModelCore.Interfaces.Images;

namespace AccountsModelCore.Classes.DocumentImages
{
    public class DocumentImage
        : IDocumentImage, IDbModel
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int SourceDocumentId { get; set; }
        public virtual SourceDocument SourceDocument { get; set; }
        public string SourceDocumentText { get; set; }
    }
}
