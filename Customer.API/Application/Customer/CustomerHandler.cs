using AutoMapper;
using Customer.API.Domain.Repositories;

namespace Customer.API.Application.Customer
{
    public class CustomerHandler : ICustomerHandler
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public CustomerHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public IEnumerable<CreatedCustomer> AddCustomers(IEnumerable<CreateCustomerCommand> customersCommand)
        {
            //TODO:Add Sorting implementation for customers
            //TODO:Add Id duplication check
            var newCustomers = _mapper.Map<IEnumerable<Domain.Entities.Customer>>(customersCommand);
            var existingCustomers = _customerRepository.GetAll();

            var allCustomers = existingCustomers.Concat(newCustomers.ToList());

            _customerRepository.Insert(allCustomers);

            return GetAllCustomers();
        }

        public IEnumerable<CreatedCustomer> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();

            return _mapper.Map<IEnumerable<CreatedCustomer>>(customers);
        }
    }
}
