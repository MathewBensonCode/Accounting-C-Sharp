namespace AccountLib.Interfaces
{
    public interface IDocumentTypeName:
        IDbModel
    {
        string Name { get; set; }
    }
}
