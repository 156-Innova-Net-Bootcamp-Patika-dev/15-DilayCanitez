using AutoMapper;
using System;
using System.Linq;
using WebApiSample.DataAccessLayer.Context;
using WebApiSample.DataAccessLayer.Entities;
using WebApiSample.Models;

namespace WebApiSample.ModelOperations.AddCustomer
{
    public class AddCustomerCommand
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerModel Model;

        public AddCustomerCommand(CustomerDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Email == Model.Email || c.PhoneNumber == Model.PhoneNumber);
            if (customer is not null)
            {
                throw new Exception("There is already a customer added with the same email or phone number. Please check the fields.");
            }
            else
            {
                customer = _mapper.Map<Customer>(Model);                
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
        }
    }
}