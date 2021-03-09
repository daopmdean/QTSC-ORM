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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReturn>>> GetCustomers(string name,
            [FromQuery] PaginationParams pagingParams)
        {
            if (name == null)
            {
                name = "";
            }

            return await _customerRepository.GetCustomers(name, pagingParams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomer(id);

            if (customer == null)
                return BadRequest($"Customer with id: {id} does not exist");

            return Ok(customer);
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomer(int customerId,
            CustomerUpdate customerUpdate)
        {
            var customer = await _customerRepository.GetCustomer(customerId);

            _mapper.Map(customerUpdate, customer);
            _customerRepository.UpdateCustomer(customer);

            if (await _customerRepository.SaveAllAsync())
                return NoContent();

            return BadRequest("Failed to update customer");
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(CustomerCreate customerCreate)
        {
            var customer = _mapper.Map<Customer>(customerCreate);
            _customerRepository.AddCustomer(customer);

            if (await _customerRepository.SaveAllAsync())
                return Ok(customer);

            return BadRequest("Failed to create Customer");
        }
    }
}
