using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSample.DataAccessLayer.Entities;
using WebApiSample.Models;

namespace WebApiSample.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<Customer, ListCustomerModel>();
            CreateMap<List<Customer>, List<ListCustomerModel>>();
            
        }
    }
}
