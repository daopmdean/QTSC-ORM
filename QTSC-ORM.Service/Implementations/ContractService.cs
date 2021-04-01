using System;
using System.Collections.Generic;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;
using QTSC_ORM.Service.Interfaces;

namespace QTSC_ORM.Service.Implementations
{
    public class ContractService : IContractService
    {
        public ContractService()
        {
        }

        public Contract GetContractByContractNo(int contractNo)
        {
            throw new NotImplementedException();
        }

        public Contract GetContractById(int contractId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContractReturn> GetContracts(PaginationParams @params)
        {
            throw new NotImplementedException();
        }
    }
}
