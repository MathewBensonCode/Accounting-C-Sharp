namespace AccountLib.Interfaces.Images
{
    public interface IDocumentImage
        : IDbModel
    {
        string Path { get; set; }

        int SourceDocumentId { get; set; }

        string SourceDocumentText { get; set; }
    }
}
