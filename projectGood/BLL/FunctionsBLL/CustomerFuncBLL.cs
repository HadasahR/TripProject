using AutoMapper;
using BLL.Interfaces;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FunctionsBLL
{
    public class CustomerFuncBLL : ICustomerBLL
    {
        private readonly DAL.Interfaces.ICustomer customerFunc;
        private readonly DAL.Interfaces.ITrips tripsFunc;
        private readonly DAL.Interfaces.IOrder orderFunc;

        private readonly IMapper mapper;
        public CustomerFuncBLL(DAL.Interfaces.ICustomer customerFunc, 
                               IMapper mapper,
                               DAL.Interfaces.ITrips trips,
                               DAL.Interfaces.IOrder orderFunc)
        {
            this.customerFunc = customerFunc;
            this.mapper = mapper;
            this.tripsFunc = trips;
            this.orderFunc = orderFunc;
        }
        public async Task<int> AddCustomerBLL(CustomerDTO customerDTO)
        {
            //אם כל בדיקות התקינות נכונות 
            if(MiddleWares.checkName(customerDTO.CustFname)&&
                MiddleWares.checkName(customerDTO.CustLname)&&
                MiddleWares.checkMail(customerDTO.CustEmail)&&
                MiddleWares.checkPhone(customerDTO.CustPhone)
                )
            {
                //בדיקה אם הלקוח לא קיים כבר 
                // int i = await orderTicketBLL.addAsync(mapper.Map<DTO.Classes.OrderTicketDTO,DAL.Models.OrderTicket>(orderTicketDTO));
                int i = await customerFunc.addAsync(mapper.Map<DTO.Classes.CustomerDTO,DAL.Models.Customer>(customerDTO));
                return i;
            }
            return -1;
        }

        public async Task<bool> DeleteCustomerBLL(int id)
        {
            var list = await GetCustomersAsyncBLL();
            CustomerDTO cust= list.FirstOrDefault(e=>e.CustId==id);
            if (cust == null)
            {
                return false;
            }
            //בדיקה שאין לו טיולים עתידיים 
            //שליפת כל ההזמנות של אותו לקוח  
            List<DTO.Classes.OrderTicketDTO> l = await GetAllTripsByCustomerBLL(cust.CustId);
            // מעבר על כל ההזמנות ובדיקה אם יש לו הזמנה לטיול שעוד לא התקים ואז א"א למחוק אותו 
           var o= l.FirstOrDefault(o=>o.TripDate>DateTime.Now);
            if (o != null)
                return false;
            bool f = await customerFunc.deleteAsync(cust.CustId);
            return f;
        }

        public async Task<List<DTO.Classes.OrderTicketDTO>> GetAllTripsByCustomerBLL(int custId)
        {
            //שליפת כל הטיולים 
            var list = await orderFunc.getAllAsync();
            list = list.FindAll(e=>e.CustId == custId);
            return mapper.Map<List<OrderTicketDTO>>(list);
        }

        public  async Task<CustomerDTO> GetByEmailAndPasswordBLL(string email, string password)
        {
            var customer = await customerFunc.getByMailAndPasswordAsync(email, password);
                return mapper.Map<CustomerDTO>(customer);
        }

        public async Task<List<CustomerDTO>> GetCustomersAsyncBLL()
        {
            var list = await customerFunc.getAllAsync();
            //  return mapper.Map<List<DTO.Classes.TypeDTO>>(list);
            return mapper.Map<List<CustomerDTO>>(list);
        }
        public async Task<bool> UpdateCustomerBLL(CustomerDTO customerDTO)
        {
            //אם כל בדיקות התקינות נכונות 
            if (MiddleWares.checkName(customerDTO.CustFname) &&
                MiddleWares.checkName(customerDTO.CustLname) &&
                MiddleWares.checkMail(customerDTO.CustEmail) &&
                MiddleWares.checkPhone(customerDTO.CustPhone)
                )
            {
                return await customerFunc.updateAsync(mapper.Map<CustomerDTO,DAL.Models.Customer>(customerDTO));
            }
            return false;
        }
    }
}
