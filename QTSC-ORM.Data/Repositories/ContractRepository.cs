using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Pagings;

namespace QTSC_ORM.Data.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly DataContext _context;

        public ContractRepository(DataContext context)
        {
            _context = context;
        }

        public void AddContract(Contract contract)
        {
            _context.Contracts.Add(contract);
        }

        public void UpdateContract(Contract customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public void DeleteContract(Contract contract)
        {
            _context.Contracts.Remove(contract);
        }

        public async Task<Contract> GetContract(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task<PagedList<Contract>> GetContracts(PaginationParams pagingParams)
        {
            var contracts = _context.Contracts.AsQueryable();

            return await PagedList<Contract>
                .CreateAsync(contracts, pagingParams.PageNumber, pagingParams.PageSize);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
