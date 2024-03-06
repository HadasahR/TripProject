using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly BLL.Interfaces.ICustomerBLL customerBLLFunc;
        public CustomerController(BLL.Interfaces.ICustomerBLL customerBLL)
        {
            this.customerBLLFunc = customerBLL;
        }
        [HttpGet]
        public async Task<List<DTO.Classes.CustomerDTO>> GetCustomers()
        {
            return await customerBLLFunc.GetCustomersAsyncBLL();
        }
        [HttpGet]
        [Route("/{mail}/{password}")]
        public async Task<DTO.Classes.CustomerDTO> GetByMailAndPassword(string mail, string password)
        {
            return await customerBLLFunc.GetByEmailAndPasswordBLL(mail, password);
        }
        [HttpPost]
        public async Task<int> AddCustomer(DTO.Classes.CustomerDTO customerDTO)
        {
            return await customerBLLFunc.AddCustomerBLL(customerDTO);
        }
        [HttpPut]
        public async Task<bool> UpdateCustomer(DTO.Classes.CustomerDTO customerDTO)
        {
            return await customerBLLFunc.UpdateCustomerBLL(customerDTO);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteCustomer(int id)
        {
            return await customerBLLFunc.DeleteCustomerBLL(id);
        }
        [HttpGet]
        [Route("/GetTripsByCust/{id}")]
        public async Task<List<DTO.Classes.OrderTicketDTO>> GetTripsByCust(int id)
        {
            return await customerBLLFunc.GetAllTripsByCustomerBLL(id);
        }
    }
}

