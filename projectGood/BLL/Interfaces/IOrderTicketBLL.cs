using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderTicketBLL
    {

        Task<List<DTO.Classes.OrderTicketDTO>> GetAllOrdersToTrip(int id);
        Task<List<DTO.Classes.OrderTicketDTO>> GetAllOrders();

        Task<int> AddOrder(DTO.Classes.OrderTicketDTO orderTicketDTO);
        Task<bool> DeleteOrder(int id);
    }
}
