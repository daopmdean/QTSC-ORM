using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;
using QTSC_ORM.Data.Repositories.Interfaces;

namespace QTSC_ORM.Data.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ContractRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddContract(Contract contract)
        {
            _context.Contracts.Add(contract);
        }

        public void UpdateContract(Contract contract)
        {
            _context.Entry(contract).State = EntityState.Modified;
        }

        public void DeleteContract(Contract contract)
        {
            _context.Contracts.Remove(contract);
        }

        public async Task<Contract> GetContractById(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task<Contract> GetContractByContractNo(int contractNo)
        {
            return await _context.Contracts
                .FirstOrDefaultAsync(c => c.ContractNo == contractNo);
        }

        public async Task<PagedList<ContractReturn>> GetContracts(PaginationParams pagingParams)
        {
            var query = _context.Contracts
                .OrderBy(c => c.ContractNo)
                .AsQueryable();

            var contracts = query.ProjectTo<ContractReturn>(_mapper.ConfigurationProvider);

            return await PagedList<ContractReturn>
                .CreateAsync(contracts, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
