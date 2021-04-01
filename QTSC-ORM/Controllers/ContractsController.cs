using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;
using QTSC_ORM.Data.Repositories.Interfaces;

namespace QTSC_ORM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractsController(IContractRepository contractRepository,
            IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractReturn>>> GetContracts(
            [FromQuery] PaginationParams pagingParams)
        {
            return await _contractRepository.GetContracts(pagingParams);
        }

        [HttpGet("{contractNo}")]
        public async Task<ActionResult<ContractInfo>> GetContract(int contractNo)
        {
            var contract = await _contractRepository.GetContractByContractNo(contractNo);

            if (contract == null)
                return BadRequest($"Contract with no: {contractNo} does not exist");

            return Ok(contract);
        }

        [HttpPut("{contractId}")]
        public async Task<ActionResult> UpdateContract(int contractId,
            ContractUpdate contractUpdate)
        {
            var contract = await _contractRepository.GetContractById(contractId);

            _mapper.Map(contractUpdate, contract);
            _contractRepository.UpdateContract(contract);

            if (await _contractRepository.SaveAllAsync())
                return NoContent();

            return BadRequest("Failed to update customer");
        }

        [HttpPost]
        public async Task<ActionResult<Contract>> AddContract(ContractCreate contractCreate)
        {
            var contract = _mapper.Map<Contract>(contractCreate);
            _contractRepository.AddContract(contract);

            if (await _contractRepository.SaveAllAsync())
                return Ok(contract);

            return BadRequest("Failed to create Customer");
        }
    }
}
