using BLL.FunctionsBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly BLL.Interfaces.IOrderTicketBLL orderTicketBLL;
        public OrderController(BLL.Interfaces.IOrderTicketBLL orderTicketBLL)
        {
            this.orderTicketBLL = orderTicketBLL;
        }
        [HttpGet]
        public async Task<List<DTO.Classes.OrderTicketDTO>> GetOrders()
        {
            return await orderTicketBLL.GetAllOrders();
        }
        [HttpGet]
        [Route("GetOrderByTrip/{id}")]
        public async Task<List<DTO.Classes.OrderTicketDTO>> GetOrderToTrip(int id)
        {
            try
            {
                return await orderTicketBLL.GetAllOrdersToTrip(id);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<int> AddOrder(DTO.Classes.OrderTicketDTO orderTicketDTO)
        {
            return await orderTicketBLL.AddOrder(orderTicketDTO);
        }
        ///

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteOrder(int id)
        {
            return await orderTicketBLL.DeleteOrder(id);
        }
    }
}
