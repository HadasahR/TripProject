using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICustomerBLL
    {
        Task<List<DTO.Classes.CustomerDTO>> GetCustomersAsyncBLL();
        Task<DTO.Classes.CustomerDTO> GetByEmailAndPasswordBLL(string email, string password);
        Task<int> AddCustomerBLL(DTO.Classes.CustomerDTO customerDTO);
        Task<bool> UpdateCustomerBLL(DTO.Classes.CustomerDTO customerDTO);
        Task<bool> DeleteCustomerBLL(int id);
        Task<List<DTO.Classes.OrderTicketDTO>> GetAllTripsByCustomerBLL(int id);
    }
}
