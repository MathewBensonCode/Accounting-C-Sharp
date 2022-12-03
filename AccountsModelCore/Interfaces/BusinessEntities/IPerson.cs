using System;

namespace AccountsModelCore.Interfaces.BusinessEntities
{
    public interface IPerson : IBusinessEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? DateOfBirth { get; set; }
        int Gender { get; set; }
    }
}
