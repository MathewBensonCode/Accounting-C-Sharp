using AccountsEntityFrameworkCore;
using AccountsModelCore.Classes;

namespace AccountsViewModel.Repositories
{
    public class DocumentTypeNameDbSetRepository :
        DbSetRepository<DocumentTypeName>
    {
        public DocumentTypeNameDbSetRepository(AccountsDbContext context) :
            base(context)
        {
        }
    }
}
