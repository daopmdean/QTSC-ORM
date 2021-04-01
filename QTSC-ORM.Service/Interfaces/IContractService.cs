using System;
using System.Collections.Generic;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;

namespace QTSC_ORM.Service.Interfaces
{
    public interface IContractService
    {
        IEnumerable<ContractReturn> GetContracts(PaginationParams @params);
        Contract GetContractByContractNo(int contractNo);
        Contract GetContractById(int contractId);
    }
}
