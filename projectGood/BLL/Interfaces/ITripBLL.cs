using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITripBLL
    {
        Task<DTO.Classes.TripDTO> GetTripByIdBLL(int id);
        //Task<List<DTO.Classes.TripDTO>> GetAllTripsBLL();
        List<DTO.Classes.TripDTO> GetAllTripsBLL();

        Task<int> AddTripBLL(DTO.Classes.TripDTO tripDTO);
        Task<bool> UpdateTripBLL(DTO.Classes.TripDTO tripDTO);
        Task<List<DTO.Classes.OrderTicketDTO>> GetInvitesToTrip(int tripId);
    }
}
