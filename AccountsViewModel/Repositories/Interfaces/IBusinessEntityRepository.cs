using System.Collections.Generic;
using AccountLib.Model.BusinessEntities;

namespace AccountsViewModel.Repositories.Interfaces
{
    public interface IBusinessEntityRepository : IRepository<BusinessEntity>
    {
        IEnumerable<BusinessEntity> GetPersonBusinessEntityAccounts();
        IEnumerable<BusinessEntity> GetRegisteredBusinessEntityAccounts();
        IEnumerable<BusinessEntity> GetCompanyBusinessEntityAccounts();
    }
}
