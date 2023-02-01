namespace AccountsModelCore.Interfaces
{
    public interface IDocumentTypeName :
        IDbModel
    {
        string Name { get; set; }
    }
}
