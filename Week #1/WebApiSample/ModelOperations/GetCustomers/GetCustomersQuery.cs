using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiSample.DataAccessLayer.Context;
using WebApiSample.DataAccessLayer.Entities;
using WebApiSample.Models;

namespace WebApiSample.ModelOperations.GetCustomers
{
    public class GetCustomersQuery
    {
        private readonly CustomerDbContext _context;
        private readonly IMapper _mapper;
        public List<ListCustomerModel> ListVM = new List<ListCustomerModel>();
        public ListCustomerModel Customer = new ListCustomerModel();

        public GetCustomersQuery(CustomerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customerList = _context.Customers.OrderBy(c => c.CustomerId).ToList();
            ListVM = _mapper.Map<List<ListCustomerModel>>(customerList);
        }

        public void Handle(int id)
        {
            this.Handle();
            Customer = ListVM.SingleOrDefault(c => c.CustomerId == id);
            if (Customer is null)
                throw new InvalidOperationException("Belirtilen kullanıcı bulunamadı");
        }
    }
}