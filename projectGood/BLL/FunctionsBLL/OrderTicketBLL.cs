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
    public class OrderTicketBLL : IOrderTicketBLL
    {
        private readonly DAL.Interfaces.IOrder orderTicketBLL;
       private readonly DAL.Interfaces.ITrips tripsBLL;
        private readonly IMapper mapper;
        public OrderTicketBLL(DAL.Interfaces.IOrder order,IMapper mapper,DAL.Interfaces.ITrips trips) { 
        this.orderTicketBLL = order;
            this.mapper = mapper;
            this.tripsBLL = trips;
        }

        public async Task<int> AddOrder(OrderTicketDTO orderTicketDTO)
        {
            
            //שליפת כל הטיולים
            var trips =  tripsBLL.getAllAsync();
            //שליפת הטיול שרוצים להזמין לו מקום
            var thisTrip = trips.FirstOrDefault(t => t.TripId == orderTicketDTO.TripId);
            if (
               //בדיקה שתאריך הטיול לא עבר עדיין
               thisTrip.Date > DateTime.Now
                //בדיקה שיש מספיק מקומות להזמין 
                && thisTrip.EmptyPlaces > orderTicketDTO.CountPlaces
                )
            {
                DateTime t = DateTime.Now;
                orderTicketDTO.OrdDate =t;
                orderTicketDTO.OrdTime=new TimeSpan(t.Hour,t.Minute,t.Second);
                int i = await orderTicketBLL.addAsync(mapper.Map<DTO.Classes.OrderTicketDTO,DAL.Models.OrderTicket>(orderTicketDTO));
              //עדכון המקומות הפנוים בטיול 
                thisTrip.EmptyPlaces = thisTrip.EmptyPlaces - orderTicketDTO.CountPlaces;
              await  tripsBLL.updateAsync(thisTrip);
                return i;
            }
            return -1; 

        }

        public async Task<bool> DeleteOrder(int id)
        {
            //שליפת ההזמנה 
            var orders = await GetAllOrders();
            var thisOrder = orders.FirstOrDefault(o => o.OrdId == id);
            //שליפת כל הטיולים
            var trips =  tripsBLL.getAllAsync();
            //שליפת הטיול שרוצים למחוק את ההזמנות שלו
            var thisTrip = trips.FirstOrDefault(t => t.TripId ==thisOrder.TripId);
            //בדיקה שלא עבר תאריך הטיול
            if(thisTrip.Date > DateTime.Now)
            {
                //עדכון מקומות פנוים בטיול 
                thisTrip.EmptyPlaces = thisTrip.EmptyPlaces + thisOrder.CountPlaces;
                await tripsBLL.updateAsync(thisTrip);
                //מחיקת ההזמנה
                return await orderTicketBLL.deleteAsync(id);
               
            }
            return false;
        }

        public async Task<List<OrderTicketDTO>> GetAllOrders()
        {
            var list = await orderTicketBLL.getAllAsync();
            return mapper.Map<List<OrderTicketDTO>>(list);
        }

        public async Task<List<OrderTicketDTO>> GetAllOrdersToTrip(int id)
        {
            var list = await orderTicketBLL.getAllAsync();
            list= list.FindAll(e=>e.TripId == id);
            return mapper.Map<List<OrderTicketDTO>>(list);
        }
        
    }
}
