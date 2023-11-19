using Customer.API.Application.Customer;

namespace Customer.API.Domain.Repositories
{
    public interface ICustomerRepository
    {
        public void Insert(IEnumerable<Entities.Customer> customers);

        public IEnumerable<Domain.Entities.Customer> GetAll();
    }
}
