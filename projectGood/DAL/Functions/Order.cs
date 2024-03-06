using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class Order : IOrder
    {
        IContext db;
        public Order(IContext db)
        {
            this.db = db;
        }

        public async Task<List<OrderTicket>> getAllAsync()
        {
            
            return await db.OrderTickets.
                 Include(o => o.Trip).
                Include(c => c.Cust)
                .ToListAsync();

        }

        public async Task<OrderTicket> getByIdAsync(int id)
        {
                var order = await db.OrderTickets.
                Include(o=>o.Trip).
                Include(c=>c.Cust).
                FirstOrDefaultAsync(p =>p.OrdId==id);
                return order;
        }
       public async Task<int> addAsync(OrderTicket ticket)
        {
            try
            {
                db.OrderTickets.Add(ticket);
                await db.SaveChangesAsync();
                return db.OrderTickets.Count();
            }
            catch (Exception)
            {
                return -1;
            }
        }

    public  async Task<bool> deleteAsync(int id)
        {
            try
            {
               // var order = await db.OrderTickets.FindAsync(id);
                db.OrderTickets.Remove(db.OrderTickets.FirstOrDefault(u => u.OrdId == id));
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        

    }
}
