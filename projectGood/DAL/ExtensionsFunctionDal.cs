using DAL.Functions;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public static class ExtensionsFunctionDal
    {
        public static void AddInjectionDAL(this IServiceCollection services)
        {
           //הזרקות כל ממשק למחלקה המתאימה שצריכה לקבל אותו בבנאי 
            services.AddScoped<ICustomer,DAL.Functions.Customer>();
            services.AddScoped<IOrder, DAL.Functions.Order>();
            services.AddScoped<ITypes, DAL.Functions.Type>();
            services.AddScoped<ITrips, DAL.Functions.Trip>();
        }
    }
}
