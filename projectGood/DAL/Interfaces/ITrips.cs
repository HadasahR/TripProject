using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface ITrips
    {
      //  Task< List<Trip>> getAllAsync();
      List<Trip>  getAllAsync();
        Task<Trip> getByIdAsync(int id);
       Task< bool> deleteAsync(int id);
        Task<int> addAsync(Trip trip);
       Task< bool> updateAsync(Trip trip);

    }
}
