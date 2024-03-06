using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class Trip : ITrips
    {
        IContext db;
        public Trip(IContext db) {
         this.db = db;  
        }

        public async Task<int> addAsync(Models.Trip trip)
        {
            try
            {
                db.Trips.Add(trip);
                await db.SaveChangesAsync();
                return db.Trips.Count();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<bool> deleteAsync(int id)
        {
            try
            {
                var Trip = await db.Trips.FindAsync(id);
                db.Trips.Remove(Trip);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public  List<Models.Trip> getAllAsync()
        {
            var r =  db.Trips.Include("Type").ToList();
            return r;

        }
        public async Task<Models.Trip> getByIdAsync(int id)
        {
            var trip = await db.Trips.FirstOrDefaultAsync(p => p.TripId == id);
            return trip;
        }

        public async Task<bool> updateAsync(Models.Trip trip)
        {
            try
            {
                //
                var TripToUpdate = await getByIdAsync(trip.TripId);
                if (TripToUpdate == null)
                {
                    //  logger.LogError("the id  does not exist");
                    return false;
                }
                TripToUpdate.Destination = trip.Destination;
                TripToUpdate.EmptyPlaces = trip.EmptyPlaces;
                TripToUpdate.TypeId = trip.TypeId;
                TripToUpdate.CustId = trip.CustId;
             //   TripToUpdate.Date = trip.Date;
              //  TripToUpdate.LeavingHour = trip.LeavingHour;
                TripToUpdate.HowLong = trip.HowLong;
                TripToUpdate.Price = trip.Price;
                TripToUpdate.Img = trip.Img;
                //
                TripToUpdate.OrderTickets = trip.OrderTickets;
                TripToUpdate.Type = trip.Type;

               await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
