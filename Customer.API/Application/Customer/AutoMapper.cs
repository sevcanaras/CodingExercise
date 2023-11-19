using AutoMapper;

namespace Customer.API.Application.Customer
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateCustomerCommand, Domain.Entities.Customer>();
            CreateMap<Domain.Entities.Customer, CreatedCustomer>();

        }
    }
}
