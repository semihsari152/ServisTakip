using ServisTakipWebAPI.Models;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;

namespace ServisTakipWebAPI.Services
{

    public interface ICustomerService
    {
        List<CustomerResponseModel> GetAllCustomers();
        CustomerResponseModel GetCustomerById(int productId);
        int CreateCustomer(CustomerRequestModel customerRequest);
        void UpdateCustomer(int customerId, CustomerRequestModel customerRequest);
        void DeleteCustomer(int customerId);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ServisTakipDbContext _dbContext;

        public CustomerService(ServisTakipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateCustomer(CustomerRequestModel request)
        {
            var newCustomer = new Customer
            {
                CustomerName = request.CustomerName,
                CustomerPhone = request.CustomerPhone,
                CustomerEmail = request.CustomerEmail,
                CustomerCity = request.CustomerCity,
                CustomerCounty = request.CustomerCounty
                // Other properties can be set similarly
            };

            _dbContext.Customers.Add(newCustomer);
            _dbContext.SaveChanges();

            return newCustomer.CustomerID;
        }

        public void DeleteCustomer(int id)
        {
            var customerToDelete = _dbContext.Customers.Find(id);
            if (customerToDelete == null)
            {
                return;
            }

            _dbContext.Customers.Remove(customerToDelete);
            _dbContext.SaveChanges();
        }

        public List<CustomerResponseModel> GetAllCustomers()
        {
            var customers = _dbContext.Customers.ToList();
            var customerResponses = customers.Select(MapToCustomerResponse).ToList();
            return customerResponses;
        }

        public CustomerResponseModel GetCustomerById(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer == null)
            {
                return null;
            }

            return MapToCustomerResponse(customer);
        }

        public void UpdateCustomer(int id, CustomerRequestModel request)
        {
            var existingCustomer = _dbContext.Customers.Find(id);
            if (existingCustomer == null)
            {
                return;
            }

            existingCustomer.CustomerName = request.CustomerName;
            existingCustomer.CustomerPhone = request.CustomerPhone;
            existingCustomer.CustomerEmail = request.CustomerEmail;
            existingCustomer.CustomerCity = request.CustomerCity;
            existingCustomer.CustomerCounty = request.CustomerCounty;
            // Update other properties similarly

            _dbContext.SaveChanges();
        }

        private CustomerResponseModel MapToCustomerResponse(Customer customer)
        {
            return new CustomerResponseModel
            {
                CustomerID = customer.CustomerID,
                CustomerName = customer.CustomerName,
                CustomerPhone = customer.CustomerPhone,
                CustomerEmail = customer.CustomerEmail,
                CustomerCity = customer.CustomerCity,
                CustomerCounty = customer.CustomerCounty
                // Other properties can be mapped similarly
            };
        }

    }
}
