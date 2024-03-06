using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type=  DAL.Models.Type;
namespace DAL
{
    public interface IContext
    {
        public DbSet<OrderTicket> OrderTickets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Trip> Trips { get; set; }
        

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));


    }
}
