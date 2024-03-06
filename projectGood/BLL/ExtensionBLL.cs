using BLL.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace BLL
{
    public static class ExtensionBLL
    {
        public static void AddInjectionBLL(this IServiceCollection services)
        {
            //DALהזרקת פונקצית ההרחבה מה
            services.AddInjectionDAL();
            services.AddScoped<ICustomerBLL,BLL.FunctionsBLL.CustomerFuncBLL>();
            services.AddScoped<ITripBLL,BLL.FunctionsBLL.TripFuncBLL>();
            services.AddScoped<IOrderTicketBLL,BLL.FunctionsBLL.OrderTicketBLL>();
            services.AddScoped<ITypeBLL,BLL.FunctionsBLL.TypeFuncBLL>();
            services.AddSingleton<IContext, TripsProjectContext>();
            services.AddAutoMapper(typeof(DTO.Mapper));
        }
    }
}
