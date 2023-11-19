using Customer.API.Domain.Repositories;
using System.Text.Json;

namespace Customer.API.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string DATABASE_STRING_PATH = "CustomerFakeDatabase.json";
        public void Insert(IEnumerable<Domain.Entities.Customer> customers)
        {
            var customersJson = JsonSerializer.Serialize(customers);
            File.WriteAllText(DATABASE_STRING_PATH, customersJson);
        }

        public IEnumerable<Domain.Entities.Customer> GetAll()
        {
            string jsonString = File.ReadAllText(DATABASE_STRING_PATH);
            return JsonSerializer.Deserialize<IEnumerable<Domain.Entities.Customer>>(jsonString)
                ?? new List<Domain.Entities.Customer>();
        }
    }
}
