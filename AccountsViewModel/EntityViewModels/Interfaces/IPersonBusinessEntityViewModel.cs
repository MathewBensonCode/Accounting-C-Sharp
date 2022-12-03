using System;

namespace AccountsViewModel.EntityViewModels.Interfaces
{
    public interface IPersonBusinessEntityViewModel
        : IBusinessEntityViewModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? DateOfBirth { get; set; }
        int Gender { get; set; }
    }
}
