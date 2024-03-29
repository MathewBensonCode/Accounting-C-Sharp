﻿using AccountsViewModel.EntityViewModels.Interfaces;

namespace AccountsViewModel.Services.Interfaces
{
    public interface IViewModelCopyService<T> where T : class
    {
        void CopyEntityViewModel(IEntityViewModel<T> copyfrom, IEntityViewModel<T> copyto);
    }
}
