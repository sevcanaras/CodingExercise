namespace Customer.API.Application.Customer
{
    public interface ICustomerHandler
    {
        IEnumerable<CreatedCustomer> AddCustomers(IEnumerable<CreateCustomerCommand> customers);

        IEnumerable<CreatedCustomer> GetAllCustomers();
    }
}
