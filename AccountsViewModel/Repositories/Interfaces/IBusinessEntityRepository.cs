using AccountLib.Model.BusinessEntities;
using System.Collections.Generic;

namespace Accounts.Repositories
{
    public interface IBusinessEntityRepository:IRepository<BusinessEntity>
    {
        IEnumerable<BusinessEntity> GetPersonBusinessEntityAccounts();
        IEnumerable<BusinessEntity> GetRegisteredBusinessEntityAccounts();
        IEnumerable<BusinessEntity> GetCompanyBusinessEntityAccounts();
    }
}
