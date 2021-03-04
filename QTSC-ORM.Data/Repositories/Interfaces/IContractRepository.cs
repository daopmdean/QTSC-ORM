using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Pagings;

namespace QTSC_ORM.Data.Repositories.Interfaces
{
    public interface IContractRepository
    {
        void AddContract(Contract contract);
        void UpdateContract(Contract contract);
        void DeleteContract(Contract contract);
        Task<Contract> GetContract(int id);
        Task<PagedList<Contract>> GetContracts(PaginationParams pagingParams);
        Task<bool> SaveAllAsync();
    }
}
