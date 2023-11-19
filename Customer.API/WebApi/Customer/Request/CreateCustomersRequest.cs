using System.ComponentModel.DataAnnotations;

namespace Customer.API.WebApi.Customer.Request
{
    public class CreateCustomersRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "Customer request should contain at least one customer!")]
        public required IEnumerable<CustomerRequest> Customers { get; set; }
    }

    public class CustomerRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0.")]
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        [Range(18, int.MaxValue, ErrorMessage = "Age must be 18 or older.")]
        public int Age { get; set; }
    }
}
