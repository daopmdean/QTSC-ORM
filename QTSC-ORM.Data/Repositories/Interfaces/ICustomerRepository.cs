using System;
using System.Threading.Tasks;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;

namespace QTSC_ORM.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Task<Customer> GetCustomer(int id);
        Task<PagedList<CustomerReturn>> GetCustomers(string name, PaginationParams pagingParams);
        Task<bool> SaveAllAsync();
    }
}
