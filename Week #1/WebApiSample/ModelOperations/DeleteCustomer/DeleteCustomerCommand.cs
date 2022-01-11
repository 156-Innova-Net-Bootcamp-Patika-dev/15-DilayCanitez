using System;
using System.Linq;
using WebApiSample.DataAccessLayer.Context;

namespace WebApiSample.ModelOperations.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        private readonly CustomerDbContext _context;
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(CustomerDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == CustomerId);
            if (customer is null)
                throw new InvalidOperationException("Belirtilen kullanıcı bulunamadı");
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}