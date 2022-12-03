using AccountLib.Interfaces;
using AccountLib.Interfaces.Images;
using AccountLib.Model.SourceDocuments;

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
