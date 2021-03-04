using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;

namespace QTSC_ORM.Data.Repositories
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Task<Customer> GetCustomer(int id);
        Task<PagedList<CustomerReturn>> GetCustomers(PaginationParams pagingParams);
        Task<bool> SaveAllAsync();
    }
}
