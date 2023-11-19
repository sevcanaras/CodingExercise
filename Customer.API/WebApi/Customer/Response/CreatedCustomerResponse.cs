namespace Customer.API.WebApi.Customer.Response
{
    public class CreatedCustomersResponse
    {
        public IEnumerable<CustomerResponse> Customers { get; set; }
    }

    public class CustomerResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
