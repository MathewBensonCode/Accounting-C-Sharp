using AccountLib.Model;
using AccountLib.Model.Accounts;
using AccountLib.Model.BusinessEntities;
using AccountLib.Model.SourceDocuments;
using AccountLib.Model.Transactions;
using Accounts.Repositories;
using AccountLib.Model.Source_Documents;
using AccountLib.Interfaces;
using AccountLib.Interfaces.Accounts;
using AccountLib.Interfaces.Images;
using AccountLib.Interfaces.SourceDocuments;
using AccountLib.Interfaces.Transactions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using AccountsViewModel.CollectionCrudViews;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels;
using AccountsViewModel.CollectionViewModels.AccountCollectionViewModels;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.CommandViewModels.CollectionCommands;
using AccountsViewModel.CommandViewModels.CollectionCommands.Interfaces;
using AccountsViewModel.CommandViewModels.ImageCommands;
using AccountsViewModel.CommandViewModels.SourceDocumentCommands;
using AccountsViewModel.EntityViewModels;
using AccountsViewModel.EntityViewModels.Interfaces;
using AccountsViewModel.Factories;
using AccountsViewModel.Factories.Interfaces;
using AccountsViewModel.Factories.Interfaces.ColectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Interfaces.CollectionViewModelFactories;
using AccountsViewModel.Factories.Interfaces.CommandViewModelFactories;
using AccountsViewModel.Factories.Interfaces.RegexFactories;
using AccountsViewModel.Factories.Interfaces.ViewModelFactories;
using AccountsViewModel.Factories.Repositories.Interfaces;
using AccountsViewModel.Factories.Unity;
using AccountsViewModel.Factories.Unity.CollectionCrudViewStateFactories;
using AccountsViewModel.Factories.Unity.CollectionViewModelFactories;
using AccountsViewModel.Factories.Unity.CommandViewModelFactories;
using AccountsViewModel.Factories.Unity.RepositoryFactories;
using AccountsViewModel.Factories.Unity.ViewModelFactories;
using AccountsViewModel.Repositories;
using AccountsViewModel.Repositories.DbSetRepositories;
using AccountsViewModel.Services.Interfaces;
using AccountsViewModel.Services.ViewModelCollectionCopyService;
using AccountsViewModel.Services.ViewModelCopyService;
using Unity;
using Unity.Injection;
using AccountsViewModel.EntityViewModels.Classes.Transactions;
using AccountsViewModel.EntityViewModels.Classes.BusinessEntitySourceDocumentTypes;
using AccountsViewModel.EntityViewModels.Classes.Accounts;
using AccountsViewModel.EntityViewModels.Classes.SourceDocuments;
using AccountsViewModel.EntityViewModels.Classes.BusinessEntities;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsViewModel.EntityViewModels.Classes.DocumentImages;
using AccountsModelCore.Classes.DocumentImages;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.Services
{
    public class UnityRegisterService
    {
        public void Register(IUnityContainer container)
        {
            //Entities
            _ = container.RegisterType(typeof(IAssetAccount), typeof(AssetAccount));
            _ = container.RegisterType(typeof(ICapitalAccount), typeof(CapitalAccount));
            _ = container.RegisterType(typeof(ICurrencyAccount), typeof(CurrencyAccount));
            _ = container.RegisterType(typeof(IExpenseAccount), typeof(ExpenseAccount));
            _ = container.RegisterType(typeof(IIncomeAccount), typeof(IncomeAccount));
            _ = container.RegisterType(typeof(ILiabilityAccount), typeof(LiabilityAccount));
            _ = container.RegisterType(typeof(ITradeItemAssetAccount), typeof(TradeItemAssetAccount));

            _ = container.RegisterType(typeof(IPerson), typeof(Person));
            _ = container.RegisterType(typeof(IRegisteredBusiness), typeof(RegisteredBusiness));
            _ = container.RegisterType(typeof(ICompany), typeof(Company));

            _ = container.RegisterType(typeof(ITransaction), typeof(Transaction));
            _ = container.RegisterType(typeof(IAssetPurchaseTransaction), typeof(AssetPurchaseTransaction));
            _ = container.RegisterType(typeof(IAssetSaleTransaction), typeof(AssetSaleTransaction));
            _ = container.RegisterType(typeof(ICapitalAdditionTransaction), typeof(CapitalAdditionTransaction));
            _ = container.RegisterType(typeof(ICapitalDrawingTransaction), typeof(CapitalDrawingTransaction));
            _ = container.RegisterType(typeof(IExpenseTransaction), typeof(ExpenseTransaction));
            _ = container.RegisterType(typeof(IIncomeTransaction), typeof(IncomeTransaction));
            _ = container.RegisterType(typeof(ILiabilityDecreaseTransaction), typeof(LiabilityDecreaseTransaction));
            _ = container.RegisterType(typeof(ILiabilityIncreaseTransaction), typeof(LiabilityIncreaseTransaction));

            _ = container.RegisterType(typeof(ISourceDocument), typeof(SourceDocument));

            _ = container.RegisterType(typeof(ICountry), typeof(Country));

            _ = container.RegisterType(typeof(IDocumentImage), typeof(DocumentImage));

            _ = container.RegisterType(typeof(IDocumentTypeName), typeof(DocumentTypeName));

            _ = container.RegisterType(typeof(IBusinessEntitySourceDocumentType), typeof(BusinessEntitySourceDocumentType));

            //collections
            _ = container.RegisterType(typeof(ICollection<>), typeof(List<>));

            //EntityViewModels
            _ = container.RegisterType(typeof(IDocumentImageViewModel), typeof(DocumentImageViewModel));

            _ = container.RegisterType(typeof(IEntityViewModel<DocumentTypeName>), typeof(DocumentTypeNameViewModel));

            _ = container.RegisterType(typeof(IEntityViewModel<BusinessEntitySourceDocumentType>), typeof(BusinessEntitySourceDocumentTypeViewModel));

            _ = container.RegisterType(typeof(IEntityViewModel<AssetAccount>), typeof(AssetAccountViewModel));
            _ = container.RegisterType(typeof(IEntityViewModel<CapitalAccount>), typeof(CapitalAccountViewModel));
            _ = container.RegisterType(typeof(IEntityViewModel<CurrencyAccount>), typeof(CurrencyAccountViewModel));
            _ = container.RegisterType(typeof(IEntityViewModel<ExpenseAccount>), typeof(ExpenseAccountViewModel));
            _ = container.RegisterType(typeof(IEntityViewModel<IncomeAccount>), typeof(IncomeAccountViewModel));
            _ = container.RegisterType(typeof(IEntityViewModel<LiabilityAccount>), typeof(LiabilityAccountViewModel));

            _ = container.RegisterType(typeof(IEntityViewModel<SourceDocument>), typeof(SourceDocumentViewModel));
            _ = container.RegisterType(typeof(IEntityViewModel<BusinessEntity>), typeof(BusinessEntityViewModel));
            _ = container.RegisterType(typeof(IEntityViewModel<Country>), typeof(EntityViewModel<Country>));
            _ = container.RegisterType(typeof(IEntityViewModel<DocumentImage>), typeof(DocumentImageViewModel));
            _ = container.RegisterType(typeof(IEntityViewModel<SourceDocument>), typeof(SourceDocumentViewModel));

            //TransactionEntityViewModels
            _ = container.RegisterType(typeof(IEntityViewModel<Transaction>), typeof(ExpenseTransactionViewModel), "ExpenseTransaction");
            _ = container.RegisterType(typeof(IEntityViewModel<Transaction>), typeof(IncomeTransactionViewModel), "IncomeTransaction");
            _ = container.RegisterType(typeof(IEntityViewModel<Transaction>), typeof(AssetSaleTransactionViewModel), "AssetSaleTransaction");
            _ = container.RegisterType(typeof(IEntityViewModel<Transaction>), typeof(AssetPurchaseTransactionViewModel), "AssetPurchaseTransaction");
            _ = container.RegisterType(typeof(IEntityViewModel<Transaction>), typeof(CapitalAdditionTransactionViewModel), "CapitalAdditionTransaction");
            _ = container.RegisterType(typeof(IEntityViewModel<Transaction>), typeof(CapitalDrawingTransactionViewModel), "CapitalDrawingTransaction");
            _ = container.RegisterType(typeof(IEntityViewModel<Transaction>), typeof(LiabilityIncreaseTransactionViewModel), "LiabilityIncreaseTransaction");
            _ = container.RegisterType(typeof(IEntityViewModel<Transaction>), typeof(LiabilityDecreaseTransactionViewModel), "LiabilityDecreaseTransaction");

            //BusinessEntityViewModels
            _ = container.RegisterType(typeof(IEntityViewModel<BusinessEntity>), typeof(PersonBusinessEntityViewModel), "Person");
            _ = container.RegisterType(typeof(IEntityViewModel<BusinessEntity>), typeof(CompanyBusinessEntityViewModel), "Company");
            _ = container.RegisterType(typeof(IEntityViewModel<BusinessEntity>), typeof(RegisteredBusinessEntityViewModel), "RegisteredBusiness");

            //EntityCollectionViewModel
            //  _= container.RegisterType(typeof(IEntityCollectionViewModel<>), typeof(EntityCollectionViewModel<>));

            //AccountEntityCollectionViewModels
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<Account>), typeof(AccountCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<AssetAccount>), typeof(AssetAccountCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<CapitalAccount>), typeof(CapitalAccountCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<CurrencyAccount>), typeof(CurrencyAccountCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<ExpenseAccount>), typeof(ExpenseAccountCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<IncomeAccount>), typeof(IncomeAccountCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<LiabilityAccount>), typeof(LiabilityAccountCollectionViewModel));

            _ = container.RegisterType(typeof(IEntityCollectionViewModel<SourceDocument>), typeof(SourceDocumentCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<BusinessEntity>), typeof(BusinessEntityCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<DocumentImage>), typeof(ImageCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<Transaction>), typeof(TransactionCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<DocumentTypeName>), typeof(DocumentTypeNameCollectionViewModel));
            _ = container.RegisterType(typeof(IEntityCollectionViewModel<BusinessEntitySourceDocumentType>), typeof(BusinessEntitySourceDocumentTypeCollectionViewModel));

            //EntityAddCollectionViewModelStates
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<>), typeof(AddNewEntityToCollectionViewModelState<>));

            //AccountEntityAddCollectionViewModelStates
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<AssetAccount>), typeof(AssetAccountAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<CapitalAccount>), typeof(CapitalAccountAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<CurrencyAccount>), typeof(CurrencyAccountAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<ExpenseAccount>), typeof(ExpenseAccountAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<IncomeAccount>), typeof(IncomeAccountAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<LiabilityAccount>), typeof(LiabilityAccountAddCollectionViewModelState));

            _ = container.RegisterType(typeof(ICollectionAddViewModelState<SourceDocument>), typeof(SourceDocumentAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<BusinessEntity>), typeof(BusinessEntityAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<DocumentImage>), typeof(ImageAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<Transaction>), typeof(TransactionAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<Account>), typeof(AccountAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<BusinessEntitySourceDocumentType>), typeof(BusinessEntitySourceDocumentTypeAddCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionAddViewModelState<DocumentTypeName>), typeof(DocumentTypeNameAddCollectionViewModelState));

            //EntityEditCollectionViewModelStates
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<>), typeof(EditEntityInCollectionViewModelState<>));

            //AccountEntityEditCollectionViewModelStates
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<AssetAccount>), typeof(AssetAccountEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<CapitalAccount>), typeof(CapitalAccountEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<CurrencyAccount>), typeof(CurrencyAccountEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<ExpenseAccount>), typeof(ExpenseAccountEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<IncomeAccount>), typeof(IncomeAccountEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<LiabilityAccount>), typeof(LiabilityAccountEditCollectionViewModelState));

            _ = container.RegisterType(typeof(ICollectionEditViewModelState<SourceDocument>), typeof(SourceDocumentEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<BusinessEntity>), typeof(BusinessEntityEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<DocumentImage>), typeof(ImageEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<Transaction>), typeof(TransactionEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<Account>), typeof(AccountEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<BusinessEntitySourceDocumentType>), typeof(BusinessEntitySourceDocumentTypeEditCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionEditViewModelState<DocumentTypeName>), typeof(DocumentTypeNameEditCollectionViewModelState));

            //EntityListCollectionViewModelStates
            _ = container.RegisterType(typeof(ICollectionListViewModelState<>), typeof(EntityListCollectionViewModelState<>));

            //AccountEntityListCollectionViewModelStates
            _ = container.RegisterType(typeof(ICollectionListViewModelState<AssetAccount>), typeof(AssetAccountListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<CapitalAccount>), typeof(CapitalAccountListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<CurrencyAccount>), typeof(CurrencyAccountListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<ExpenseAccount>), typeof(ExpenseAccountListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<IncomeAccount>), typeof(IncomeAccountListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<LiabilityAccount>), typeof(LiabilityAccountListCollectionViewModelState));

            _ = container.RegisterType(typeof(ICollectionListViewModelState<SourceDocument>), typeof(SourceDocumentListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<BusinessEntity>), typeof(BusinessEntityListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<DocumentImage>), typeof(ImageListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<Transaction>), typeof(TransactionListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<Account>), typeof(AccountListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<BusinessEntitySourceDocumentType>), typeof(BusinessEntitySourceDocumentTypeListCollectionViewModelState));
            _ = container.RegisterType(typeof(ICollectionListViewModelState<DocumentTypeName>), typeof(DocumentTypeNameListCollectionViewModelState));

            //CommandViewModels
            _ = container.RegisterType(typeof(ICommandViewModel), typeof(CommandViewModel));

            //EntityViewModel factories
            _ = container.RegisterType(typeof(IAccountViewModelFactory), typeof(AccountUnityViewModelFactory));

            _ = container.RegisterType(typeof(IBusinessEntityViewModelFactory), typeof(BusinessEntityUnityViewModelFactory));
            _ = container.RegisterType(typeof(ICountryViewModelFactory), typeof(CountryUnityViewModelFactory));
            _ = container.RegisterType(typeof(ISourceDocumentViewModelFactory), typeof(SourceDocumentUnityViewModelFactory));
            _ = container.RegisterType(typeof(IDocumentTypeNameViewModelFactory), typeof(DocumentTypeNameUnityViewModelFactory));
            _ = container.RegisterType(typeof(IBusinessEntitySourceDocumentTypeViewModelFactory), typeof(BusinessEntitySourceDocumentTypeUnityViewModelFactory));
            _ = container.RegisterType(typeof(IViewModelFactory<BusinessEntity>), typeof(BusinessEntityUnityViewModelFactory));
            _ = container.RegisterType(typeof(IViewModelFactory<Transaction>), typeof(TransactionUnityViewModelFactory));
            _ = container.RegisterType(typeof(IViewModelFactory<>), typeof(UnityViewModelFactory<>));

            //EntityCollectionViewModelFactories
            _ = container.RegisterType(typeof(ICollectionViewModelFactory<>), typeof(UnityCollectionViewModelFactory<>));
            _ = container.RegisterType(typeof(IImageChildCollectionViewModelFactory), typeof(ImageChildCollectionViewModelFactory));
            _ = container.RegisterType(typeof(ISourceDocumentChildCollectionViewModelFactory), typeof(SourceDocumentChildCollectionViewModelFactory));
            _ = container.RegisterType(typeof(ITransactionChildCollectionViewModelFactory), typeof(TransactionChildCollectionViewModelFactory));
            _ = container.RegisterType(typeof(IBusinessEntityChildCollectionViewModelFactory), typeof(BusinessEntityChildCollectionViewModelFactory));
            _ = container.RegisterType(typeof(IBusinessEntitySourceDocumentTypeChildCollectionViewModelFactory), typeof(BusinessEntitySourceDocumentTypeChildCollectionViewModelFactory));
            _ = container.RegisterType(typeof(ITransactionAccountSelectionCollectionViewModelFactory), typeof(TransactionAccountSelectionCollectionViewModelFactory));

            //CommandViewModelFactories
            _ = container.RegisterType(typeof(ICommandViewModelFactory<>), typeof(CollectionCommandViewModelFactory<>));
            _ = container.RegisterType(typeof(IImageViewModelCommandFactory), typeof(UnityImageViewModelCommandFactory));
            _ = container.RegisterType(typeof(ISourceDocumentCollectionAddEditViewModelStateCommandFactory), typeof(UnitySourceDocumentCollectionAddEditViewModelStateCommandFactory));

            //CollectionCrudViewStateFactories
            _ = container.RegisterType(typeof(ICollectionCrudAddViewStateFactory<>), typeof(CollectionCrudAddViewStateFactory<>));

            _ = container.RegisterType(typeof(ICollectionCrudAddViewStateFactory<AssetAccount>), typeof(AssetAccountAddCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudAddViewStateFactory<CapitalAccount>), typeof(CapitalAccountAddCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudAddViewStateFactory<CurrencyAccount>), typeof(CurrencyAccountAddCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudAddViewStateFactory<ExpenseAccount>), typeof(ExpenseAccountAddCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudAddViewStateFactory<IncomeAccount>), typeof(IncomeAccountAddCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudAddViewStateFactory<LiabilityAccount>), typeof(LiabilityAccountAddCollectionViewModelStateFactory));

            _ = container.RegisterType(typeof(ICollectionCrudEditViewStateFactory<>), typeof(CollectionCrudEditViewStateFactory<>));

            _ = container.RegisterType(typeof(ICollectionCrudEditViewStateFactory<AssetAccount>), typeof(AssetAccountEditCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudEditViewStateFactory<CapitalAccount>), typeof(CapitalAccountEditCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudEditViewStateFactory<CurrencyAccount>), typeof(CurrencyAccountEditCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudEditViewStateFactory<ExpenseAccount>), typeof(ExpenseAccountEditCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudEditViewStateFactory<IncomeAccount>), typeof(IncomeAccountEditCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudEditViewStateFactory<LiabilityAccount>), typeof(LiabilityAccountEditCollectionViewModelStateFactory));

            _ = container.RegisterType(typeof(ICollectionCrudListViewStateFactory<>), typeof(CollectionCrudListViewStateFactory<>));

            _ = container.RegisterType(typeof(ICollectionCrudListViewStateFactory<AssetAccount>), typeof(AssetAccountListCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudListViewStateFactory<CapitalAccount>), typeof(CapitalAccountListCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudListViewStateFactory<CurrencyAccount>), typeof(CurrencyAccountListCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudListViewStateFactory<ExpenseAccount>), typeof(ExpenseAccountCollectionCrudListViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudListViewStateFactory<IncomeAccount>), typeof(IncomeAccountListCollectionViewModelStateFactory));
            _ = container.RegisterType(typeof(ICollectionCrudListViewStateFactory<LiabilityAccount>), typeof(LiabilityAccountListCollectionViewModelStateFactory));

            //RepositoryFactories
            _ = container.RegisterType(typeof(IRepositoryFactory<>), typeof(RepositoryFactory<>));

            //Repositories
            //AccountRepositoryTypes
            //         _= container.RegisterType(typeof(IAccountRepository), typeof(AccountsRepository));
            _ = container.RegisterType(typeof(IRepository<Account>), typeof(AccountDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<AssetAccount>), typeof(AssetAccountDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<CapitalAccount>), typeof(CapitalAccountDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<CurrencyAccount>), typeof(CurrencyAccountDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<ExpenseAccount>), typeof(ExpenseAccountDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<IncomeAccount>), typeof(IncomeAccountDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<LiabilityAccount>), typeof(LiabilityAccountDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<TradeItemAssetAccount>), typeof(TradeItemAssetAccountDbSetRepository));

            //BusinesssEntityTypes
            _ = container.RegisterType(typeof(IRepository<BusinessEntity>), typeof(BusinessEntityDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<IRegisteredBusiness>), typeof(RegisteredBusinessDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<Company>), typeof(CompanyDbSetRepository));

            _ = container.RegisterType(typeof(IRepository<DocumentImage>), typeof(ImageDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<SourceDocument>), typeof(SourceDocumentDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<Transaction>), typeof(TransactionDbSetRepository));

            _ = container.RegisterType(typeof(IRepository<Country>), typeof(CountryDbSetRepository));
            _ = container.RegisterType(typeof(IRepository<DocumentTypeName>), typeof(DocumentTypeNameDbSetRepository));

            _ = container.RegisterType(typeof(IRepository<BusinessEntitySourceDocumentType>), typeof(BusinessEntitySourceDocumentTypeDbSetRepository));

            //childrepositories
            _ = container.RegisterType(typeof(IRepository<Account>), typeof(ChildCollectionRepository<Account>), "childcollection");
            _ = container.RegisterType(typeof(IRepository<SourceDocument>), typeof(ChildCollectionRepository<SourceDocument>), "childcollection");
            _ = container.RegisterType(typeof(IRepository<BusinessEntity>), typeof(ChildCollectionRepository<BusinessEntity>), "childcollection");
            _ = container.RegisterType(typeof(IRepository<DocumentImage>), typeof(ChildCollectionRepository<DocumentImage>), "childcollection");
            _ = container.RegisterType(typeof(IRepository<Transaction>), typeof(ChildCollectionRepository<Transaction>), "childcollection");
            _ = container.RegisterType(typeof(IRepository<DocumentTypeName>), typeof(ChildCollectionRepository<DocumentTypeName>), "childcollection");
            _ = container.RegisterType(typeof(IRepository<BusinessEntitySourceDocumentType>), typeof(ChildCollectionRepository<BusinessEntitySourceDocumentType>), "childcollection");

            //collections
            _ = container.RegisterType<ICollection<IEntityViewModel<Account>>, ObservableCollection<IEntityViewModel<Account>>>(new InjectionConstructor());

            //AccountCollections
            _ = container.RegisterType<ICollection<IEntityViewModel<AssetAccount>>, ObservableCollection<IEntityViewModel<AssetAccount>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<CapitalAccount>>, ObservableCollection<IEntityViewModel<CapitalAccount>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<CurrencyAccount>>, ObservableCollection<IEntityViewModel<CurrencyAccount>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<ExpenseAccount>>, ObservableCollection<IEntityViewModel<ExpenseAccount>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<IncomeAccount>>, ObservableCollection<IEntityViewModel<IncomeAccount>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<LiabilityAccount>>, ObservableCollection<IEntityViewModel<LiabilityAccount>>>(new InjectionConstructor());

            _ = container.RegisterType<ICollection<IEntityViewModel<SourceDocument>>, ObservableCollection<IEntityViewModel<SourceDocument>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<BusinessEntity>>, ObservableCollection<IEntityViewModel<BusinessEntity>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<DocumentImage>>, ObservableCollection<IEntityViewModel<DocumentImage>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<Transaction>>, ObservableCollection<IEntityViewModel<Transaction>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<DocumentTypeName>>, ObservableCollection<IEntityViewModel<DocumentTypeName>>>(new InjectionConstructor());
            _ = container.RegisterType<ICollection<IEntityViewModel<BusinessEntitySourceDocumentType>>, ObservableCollection<IEntityViewModel<BusinessEntitySourceDocumentType>>>(new InjectionConstructor());

            //viewmodelfactories
            _ = container.RegisterType(typeof(IViewModelCollectionCreationService<>), typeof(ViewModelCollectionCreationService<>));

            //collection commands
            RegisterCollectionViewModelCommandsService.Register<Account>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<AssetAccount>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<CapitalAccount>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<CurrencyAccount>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<ExpenseAccount>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<IncomeAccount>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<LiabilityAccount>(_ = container);

            RegisterCollectionViewModelCommandsService.Register<SourceDocument>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<BusinessEntity>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<DocumentImage>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<Transaction>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<DocumentTypeName>(_ = container);
            RegisterCollectionViewModelCommandsService.Register<BusinessEntitySourceDocumentType>(_ = container);

            //ImageCommands
            _ = container.RegisterType(typeof(ICommand), typeof(ScanImageCommand), "ScanImageCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(GetImageFromFileCommand), "GetImageFromFileCommand");
            _ = container.RegisterType(typeof(ICommand), typeof(GetTextFromImageCommand), "GetTextFromImageCommand");

            //TextReadService
            _ = container.RegisterType(typeof(ISourceDocumentTextReadService), typeof(SourceDocumentTextReadService));

            //SourceDocumentCommands
            _ = container.RegisterType(typeof(ICommand), typeof(ReadDataFromImageTextAddEditViewCommand), "ReadDataFromImageTextAddEditViewCommand");
            //         _= container.RegisterType(typeof(ICommand), typeof(ReadDataFromImageTextEditViewCommand), "ReadDataFromImageTextEditViewCommand");

            //viewmodel copy services
            _ = container.RegisterType(typeof(IViewModelCopyService<Account>), typeof(AccountViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<AssetAccount>), typeof(AssetAccountViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<CapitalAccount>), typeof(CapitalAccountViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<CurrencyAccount>), typeof(CurrencyAccountViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<ExpenseAccount>), typeof(ExpenseAccountViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<IncomeAccount>), typeof(IncomeAccountViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<LiabilityAccount>), typeof(LiabilityAccountViewModelCopyService));

            //_= container.RegisterType(typeof(IViewModelCopyService<Account>), typeof(AccountViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<BusinessEntity>), typeof(BusinessEntityViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<DocumentImage>), typeof(ImageViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<SourceDocument>), typeof(SourceDocumentViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<DocumentTypeName>), typeof(DocumentTypeNameViewModelCopyService));
            _ = container.RegisterType(typeof(IViewModelCopyService<BusinessEntitySourceDocumentType>), typeof(BusinessEntitySourceDocumentTypeViewModelCopyService));

            _ = container.RegisterType(typeof(IViewModelCopyService<Transaction>), typeof(TransactionViewModelCopyService));

            //entity collection copy services
            _ = container.RegisterType(typeof(IViewModelCollectionCopyService<>), typeof(ViewModelCollectionCopyService<>));
            _ = container.RegisterType(typeof(IViewModelCollectionCopyService<Account>), typeof(AccountViewModelCollectionCopyService));
            _ = container.RegisterType(typeof(IViewModelCollectionCopyService<BusinessEntity>), typeof(BusinessEntityViewModelCollectionCopyService));
            _ = container.RegisterType(typeof(IViewModelCollectionCopyService<Transaction>), typeof(TransactionViewModelCollectionCopyService));

            _ = container.RegisterType<IDictionary<string, List<string>>, Dictionary<string, List<string>>>(new InjectionConstructor());

            //Regex Factory
            _ = container.RegisterType(typeof(IRegexFactory), typeof(RegexFactory));

            //Regex
            _ = container.RegisterType<Regex>(new InjectionConstructor(typeof(string)));

        }
    }
}
