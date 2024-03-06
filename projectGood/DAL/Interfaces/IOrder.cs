using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IOrder
    {
       Task< List<OrderTicket>> getAllAsync();
        Task<OrderTicket> getByIdAsync(int id);
       Task< int> addAsync(OrderTicket ticket);
       Task< bool> deleteAsync(int id);

    }
}
