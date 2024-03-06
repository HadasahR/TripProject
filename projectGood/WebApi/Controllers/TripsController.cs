using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        BLL.Interfaces.ITripBLL tripsBLLFunc;
        public TripsController(BLL.Interfaces.ITripBLL tripsBLLFunc)
        {
            this.tripsBLLFunc = tripsBLLFunc;
        }
        [HttpGet]
        public async Task<List<DTO.Classes.TripDTO>> GetAllTrips()
        {
            var r = tripsBLLFunc.GetAllTripsBLL();
            return r;
        }
        [HttpGet]
        [Route("/{id}")]
        public async Task<DTO.Classes.TripDTO> GetTripById(int id)
        {
            return await tripsBLLFunc.GetTripByIdBLL(id);
        }
        [HttpGet]
        [Route("/GetOrdersByTrip/{id}")]
        public async Task<List<DTO.Classes.OrderTicketDTO>> GetOrdersByTrip(int id)
        {
            return await tripsBLLFunc.GetInvitesToTrip(id);
        }
        [HttpPost]
        public async Task<int> AddTrip(DTO.Classes.TripDTO tripDTO)
        {
            return await tripsBLLFunc.AddTripBLL(tripDTO);
        }
        [HttpPut]
        public async Task<bool> UpdateTrip(DTO.Classes.TripDTO tripDTO)
        {
            return await tripsBLLFunc.UpdateTripBLL(tripDTO);
        }
    }
}
