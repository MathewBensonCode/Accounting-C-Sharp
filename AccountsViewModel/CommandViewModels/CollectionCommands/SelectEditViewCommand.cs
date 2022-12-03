using AccountLib.Interfaces.Transactions;
using Prism.Commands;
using AccountsViewModel.CollectionCrudViews.Interfaces;
using AccountsViewModel.CollectionViewModels.Interfaces;
using AccountsViewModel.Factories.Interfaces;
using AccountsViewModel.Services.Interfaces;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModel.CommandViewModels.CollectionCommands
{
    public class SelectEditViewCommand<T> : DelegateCommand<string>
        where T : class
    {
        public SelectEditViewCommand(
            IViewModelCopyService<T> copyService,
            ICollectionListViewModelState<T> listViewState,
            IViewModelFactory<T> viewModelFactory,
            IEntityCollectionViewModel<T> collectionViewModel,
            ICollectionEditViewModelState<T> editViewState
            )
            : base((string type) =>
            {
                collectionViewModel.CollectionViewState = editViewState;

                var entity = listViewState.EntityViewModel.Entity;

                if (type == null && entity is IBusinessEntity)
                {
                    if (entity is IPerson)
                    {
                        type = "Person";
                    }
                    else if (entity is IRegisteredBusiness)
                    {
                        type = "RegisteredBusiness";
                    }
                    else if (entity is ICompany)
                    {
                        type = "Company";
                    }
                }

                if (type == null && entity is ITransaction)
                {
                    if (entity is IAssetPurchaseTransaction)
                    {
                        type = "AssetPurchaseTransaction";
                    }
                    else if (entity is IAssetSaleTransaction)
                    {
                        type = "AssetSaleTransaction";
                    }
                    else if (entity is ICapitalAdditionTransaction)
                    {
                        type = "CapitalAdditionTransaction";
                    }
                    else if (entity is ICapitalDrawingTransaction)
                    {
                        type = "CapitalDrawingTransaction";
                    }
                    else if (entity is IExpenseTransaction)
                    {
                        type = "ExpenseTransaction";
                    }
                    else if (entity is IIncomeTransaction)
                    {
                        type = "IncomeTransaction";
                    }
                    else if (entity is ILiabilityDecreaseTransaction)
                    {
                        type = "LiabilityDecreaseTransaction";
                    }
                    else if (entity is ILiabilityIncreaseTransaction)
                    {
                        type = "LiabilityIncreaseTransaction";
                    }
                }

                editViewState.EntityViewModel = viewModelFactory.CreateViewModelForNewEntity(type);
                copyService.CopyEntityViewModel(listViewState.EntityViewModel, editViewState.EntityViewModel);
            }
             ,
                (string type) =>
                {
                    return listViewState.EntityViewModel != null;
                }
            )
        {
        }

    }
}
