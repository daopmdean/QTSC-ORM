using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Models;
using QTSC_ORM.Data.Pagings;
using QTSC_ORM.Data.Repositories.Interfaces;

namespace QTSC_ORM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReturn>>> GetCustomers(
            [FromQuery] PaginationParams pagingParams)
        {

            return await _customerRepository.GetCustomers(pagingParams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return await _customerRepository.GetCustomer(id);
        }
    }
}
