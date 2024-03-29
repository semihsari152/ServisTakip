﻿using DataAccessLayer.Abstract;
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

        public int Create(CustomerRequestModel request)
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

        public void Delete(int id)
        {
            var customerToDelete = _dbContext.Customers.Find(id);
            if (customerToDelete == null)
            {
                return;
            }

            _dbContext.Customers.Remove(customerToDelete);
            _dbContext.SaveChanges();
        }

        public List<CustomerResponseModel> GetAll()
        {
            var customers = _dbContext.Customers.ToList();
            var customerResponses = customers.Select(MapToCustomerResponse).ToList();
            return customerResponses;
        }

        public CustomerResponseModel GetById(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer == null)
            {
                return null;
            }

            return MapToCustomerResponse(customer);
        }

        public void Update(int id, CustomerRequestModel request)
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