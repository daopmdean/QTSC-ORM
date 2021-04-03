using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;
using QTSC_ORM.Data.Repositories.Interfaces;
using QTSC_ORM.Service.Interfaces;

namespace QTSC_ORM.Service.Implementations
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public Contract GetContractByContractNo(int contractNo)
        {
            throw new NotImplementedException();
        }

        public Contract GetContractById(int contractId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContractReturn>> GetContracts(PaginationParams @params)
        {
            return await _contractRepository.GetContracts(@params);
        }
    }
}
