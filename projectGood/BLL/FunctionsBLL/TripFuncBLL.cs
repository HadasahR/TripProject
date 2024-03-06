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
    public class TripFuncBLL : ITripBLL
    {
        private readonly DAL.Interfaces.ITrips tripsDAL;
        private readonly DAL.Interfaces.IOrder orderDAL;
        private readonly IMapper mapper;
        public TripFuncBLL(DAL.Interfaces.ITrips trips,IMapper mapper, DAL.Interfaces.IOrder orderDAL)
        {
            this.tripsDAL = trips;
            this.mapper = mapper;
            this.orderDAL = orderDAL;
        }
        public async Task<int> AddTripBLL(TripDTO tripDTO)
        {
            if (tripDTO.HowLong > 1 && tripDTO.HowLong < 12&&
                tripDTO.EmptyPlaces>0&&
                tripDTO.Price>0&&
                tripDTO.Price<500
                )
               return await tripsDAL.addAsync(mapper.Map<DAL.Models.Trip>(tripDTO)); 
            return -1;
        }
        public  List<TripDTO> GetAllTripsBLL()
        {
            var list =  tripsDAL.getAllAsync();
            return mapper.Map<List<TripDTO>>(list);
        }


        public async Task<List<OrderTicketDTO>> GetInvitesToTrip(int tripId)
        {
           
            //שליפת כל ההזמנות
            var list =  await orderDAL.getAllAsync();
            //סינון ההזמנות שקשורות לטיול 
          list=list.FindAll(o=>o.TripId==tripId);
            //המרה והחזרה 
         return mapper.Map<List<OrderTicketDTO>>(list);
        }

        public async Task<TripDTO> GetTripByIdBLL(int id)
        {
            var trip=await tripsDAL.getByIdAsync(id);
            return mapper.Map<TripDTO>(trip);
        }

        public async Task<bool> UpdateTripBLL(TripDTO tripDTO)
        {
            if (tripDTO.HowLong > 1 && tripDTO.HowLong < 12 &&
               //   tripDTO.Date>DateTime.Now&&
               //    tripDTO.Date<DateTime.Now.AddMonths(3)&&
               tripDTO.EmptyPlaces > 0 &&
               tripDTO.Price > 0 &&
               tripDTO.Price < 500
               )
                return await tripsDAL.updateAsync(mapper.Map<DAL.Models.Trip > (tripDTO));
            return false;
        }
    }
}
