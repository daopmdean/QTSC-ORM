using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;

namespace QTSC_ORM.Data.Repositories.Interfaces
{
    public interface IContractRepository
    {
        void AddContract(Contract contract);
        void UpdateContract(Contract contract);
        void DeleteContract(Contract contract);
        Task<Contract> GetContractById(int id);
        Task<Contract> GetContractByContractNo(int contractNo);
        Task<PagedList<ContractReturn>> GetContracts(PaginationParams pagingParams);
        Task<bool> SaveAllAsync();
    }
}
