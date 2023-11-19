using AutoMapper;
using Customer.API.Application.Customer;
using Customer.API.WebApi.Customer.Request;
using Customer.API.WebApi.Customer.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Customer.API.WebApi.Customer.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerHandler _customerHandler;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerHandler customerHandler,
            IMapper mapper)
        {
            _customerHandler = customerHandler;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates new customers.
        /// </summary>
        /// <param name="customersRequest">The collection of the customers</param>
        /// <returns>The details of the created customers.</returns>
        [HttpPost(Name = "api/customers")]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> CreateCustomers([FromBody] CreateCustomersRequest customersRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customers = _mapper.Map<IEnumerable<CreateCustomerCommand>>(customersRequest.Customers);

            var response = _customerHandler.AddCustomers(customers);

            return Created("api/customers", response);
        }


        /// <summary>
        /// Returns all customers.
        /// </summary>
        [HttpGet(Name = "api/customers")]
        [ProducesResponseType(typeof(CreatedCustomersResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = _customerHandler.GetAllCustomers();
            var createdCustomerResponse = new CreatedCustomersResponse
            {
                Customers = _mapper.Map<IEnumerable<CustomerResponse>>(customers)
            };

            return Ok(createdCustomerResponse);
        }
    }
}
