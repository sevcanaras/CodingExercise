using AutoMapper;
using Customer.API.Application.Customer;
using Customer.API.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Customer.API.Tests.Application
{
    public class CustomerHandlerTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        public CustomerHandlerTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public void GetAllCustomers_ShouldReturnCustomers_WhenCustomersExist()
        {
            //Arrange
            _customerRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Domain.Entities.Customer>
            {
                new Domain.Entities.Customer { Id = 1, FirstName="testName", LastName="testLastName", Age=20 }
            });

            var customerHandler = new CustomerHandler(_mapperMock.Object,_customerRepositoryMock.Object);

            //Act
            var customers = customerHandler.GetAllCustomers();

            //Assert
            customers.Count().Should().Be(1);
            //TODO:Complete unit tests
        }
    }
}
