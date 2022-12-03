using AccountsEntityFrameworkCore;
using AccountLib.Model;

namespace AccountsViewModel.Repositories
{
    public class DocumentTypeNameDbSetRepository :
        DbSetRepository<DocumentTypeName>
    {
        public DocumentTypeNameDbSetRepository(AccountsDbContext context): 
            base(context)
        {
        }
    }
}
