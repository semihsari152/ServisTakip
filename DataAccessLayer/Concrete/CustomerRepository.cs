using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using ServisTakipWebAPI.Models;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CustomerRepository : ICustomerDal
    {
        private readonly ServisTakipDbContext _dbContext;

        public CustomerRepository(ServisTakipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CustomerResponseModel> GetAllCustomers()
        {
            var customers = _dbContext.Customers.ToList();
            var customerResponses = customers.Select(MapToCustomerResponse).ToList();
            return customerResponses;
        }

        public CustomerResponseModel GetCustomerById(int customerId)
        {
            var customer = _dbContext.Customers.Find(customerId);
            if (customer == null)
            {
                return null;
            }

            return MapToCustomerResponse(customer);
        }

        public int CreateCustomer(CustomerRequestModel customerRequest)
        {
            var newCustomer = new Customer
            {
                CustomerName = customerRequest.CustomerName,
                CustomerPhone = customerRequest.CustomerPhone,
                CustomerEmail = customerRequest.CustomerEmail,
                CustomerCity = customerRequest.CustomerCity,
                CustomerCounty = customerRequest.CustomerCounty
                // Other properties can be set similarly
            };

            _dbContext.Customers.Add(newCustomer);
            _dbContext.SaveChanges();

            return newCustomer.CustomerID;
        }

        public void UpdateCustomer(int customerId, CustomerRequestModel customerRequest)
        {
            var existingCustomer = _dbContext.Customers.Find(customerId);
            if (existingCustomer == null)
            {
                return;
            }

            existingCustomer.CustomerName = customerRequest.CustomerName;
            existingCustomer.CustomerPhone = customerRequest.CustomerPhone;
            existingCustomer.CustomerEmail = customerRequest.CustomerEmail;
            existingCustomer.CustomerCity = customerRequest.CustomerCity;
            existingCustomer.CustomerCounty = customerRequest.CustomerCounty;
            // Update other properties similarly

            _dbContext.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            var customerToDelete = _dbContext.Customers.Find(customerId);
            if (customerToDelete == null)
            {
                return;
            }

            _dbContext.Customers.Remove(customerToDelete);
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
