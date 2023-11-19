using AutoMapper;
using Customer.API.Application.Customer;
using Customer.API.WebApi.Customer.Request;
using Customer.API.WebApi.Customer.Response;

namespace Customer.API.WebApi.Customer
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CustomerRequest, CreateCustomerCommand>();
            CreateMap<CreatedCustomer, CustomerResponse>();

        }
    }
}
