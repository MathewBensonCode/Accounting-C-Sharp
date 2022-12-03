using AccountLib.Model;
using AccountLib.Model.Accounts;
using AccountLib.Model.BusinessEntities;
using AccountLib.Model.Source_Documents;
using AccountLib.Model.SourceDocuments;
using AccountLib.Model.TradeItems;
using AccountLib.Model.Transactions;
using AccountsModelCore.Classes.DocumentImages;
using Microsoft.EntityFrameworkCore;

namespace AccountsEntityFrameworkCore

{
    public class AccountsDbContext : DbContext
    {

        public AccountsDbContext()
        {
        }

        public AccountsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            //Configuration will be done in during creating the context in the main application

        }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            base.OnConfiguring(optionsBuilder);
        //            optionsBuilder.UseSqlite("Data Source=Accounts.db");
        //        }

        //accounttypes
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetAccount> AssetAccounts { get; set; }
        public DbSet<CapitalAccount> CapitalAccounts { get; set; }
        public DbSet<LiabilityAccount> LiabilityAccounts { get; set; }
        public DbSet<ExpenseAccount> ExpenseAccounts { get; set; }
        public DbSet<TradeItemAssetAccount> TradeItemAssetAccounts { get; set; }
        public DbSet<CurrencyAccount> CurrencyAccounts { get; set; }

        //transaction types
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AssetPurchaseTransaction> AssetPurchaseTransactions { get; set; }
        public DbSet<AssetSaleTransaction> AssetSaleTransactions { get; set; }
        public DbSet<CapitalAdditionTransaction> CapitalAdditionTransactions { get; set; }
        public DbSet<CapitalDrawingTransaction> CapitalDrawingTransactions { get; set; }
        public DbSet<ExpenseTransaction> ExpenseTransactions { get; set; }
        public DbSet<IncomeTransaction> IncomeTransactions { get; set; }
        public DbSet<LiabilityIncreaseTransaction> LiabilityIncreaseTransactions { get; set; }
        public DbSet<LiabilityDecreaseTransaction> LiabilityDecreaseTransactions { get; set; }

        //business entity types
        public DbSet<BusinessEntity> BusinessEntities { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<RegisteredBusiness> RegisteredBusinesses { get; set; }

        //source Docment types
        public DbSet<SourceDocument> SourceDocuments { get; set; }
        public DbSet<DocumentImage> Images { get; set; }

        //BusinessEntitySourceDocumentType types
        public DbSet<BusinessEntitySourceDocumentType> BusinessEntitySourceDocumentTypes { get; set; }
        public DbSet<DocumentTypeName> DocumentTypes { get; set; }

        //tradeitemtypes
        public DbSet<TradeItem> TradeItems { get; set; }
        public DbSet<HtsSection> HtsSections { get; set; }
        public DbSet<HtsChapter> HtsChapters { get; set; }
        public DbSet<SubTradeItem> SubTradeItems { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Transaction>().HasOne(t => t.CreditAccount).WithMany(a => a.Credits).HasForeignKey(f => f.CreditAccountId);
            _ = modelBuilder.Entity<Transaction>().HasOne(t => t.DebitAccount).WithMany(a => a.Debits).HasForeignKey(f => f.DebitAccountId);

            // modelBuilder.Entity<SourceDocument>(sd => sd.Property(s => s.DocumentDate).ForSqliteHasColumnType("datetime"));
            _ = modelBuilder.Entity<SubTradeItem>().HasOne(s => s.ParentTradeItem).WithMany(p => p.ChildTradeItems).HasForeignKey(s => s.TradeItemId);

            base.OnModelCreating(modelBuilder);
        }

    }

}
