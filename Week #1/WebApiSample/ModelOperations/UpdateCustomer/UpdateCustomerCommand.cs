using System;
using System.Linq;
using WebApiSample.DataAccessLayer.Context;
using WebApiSample.Models;

namespace WebApiSample.ModelOperations.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly CustomerDbContext _context;
        public UpdateCustomerModel Model { get; set; }
        public int CustomerId { get; set; }

        public UpdateCustomerCommand(CustomerDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == CustomerId);
            if (customer is null)
                throw new Exception("Belirttiğiniz kullanıcı bulunamadı.");
            customer.Name = Model.Name != default ? Model.Name : customer.Name;
            customer.Surname = Model.Surname != default ? Model.Surname : customer.Surname;
            customer.Address = Model.Address != default ? Model.Address : customer.Address;
            _context.SaveChanges();
        }
    }
}