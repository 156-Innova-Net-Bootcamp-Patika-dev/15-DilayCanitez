using MFramework.Services.FakeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApiSample.DataAccessLayer.Context;
using WebApiSample.DataAccessLayer.Entities;

namespace WebApiSample.DataAccessLayer.DataGenerator
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerDbContext(serviceProvider.GetRequiredService<DbContextOptions<CustomerDbContext>>()))
            {
                if (context.Customers.Any())
                    return;
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        context.Customers.Add(new Customer
                        {
                            Name = NameData.GetFirstName(),
                            Surname = NameData.GetSurname(),
                            Address = TextData.GetSentence(),
                            Country=PlaceData.GetCountry(),
                            Email = NetworkData.GetEmail(),
                            PhoneNumber = PhoneNumberData.GetInternationalPhoneNumber()

                        });
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
