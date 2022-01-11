using Microsoft.EntityFrameworkCore;
using WebApiSample.DataAccessLayer.Entities;

namespace WebApiSample.DataAccessLayer.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}
