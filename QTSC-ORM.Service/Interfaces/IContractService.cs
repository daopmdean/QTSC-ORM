using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;

namespace QTSC_ORM.Service.Interfaces
{
    public interface IContractService
    {
        Task<IEnumerable<ContractReturn>> GetContracts(PaginationParams @params);
        Contract GetContractByContractNo(int contractNo);
        Contract GetContractById(int contractId);
    }
}
