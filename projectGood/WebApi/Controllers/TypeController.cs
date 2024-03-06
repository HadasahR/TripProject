using BLL.Interfaces;
using DTO;
using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        readonly ITypeBLL typeBLL;
        public TypeController(ITypeBLL type)
        {
            this.typeBLL = type;
        }
        [HttpGet]

        public async Task<List<DTO.Classes.TypeDTO>> GetTypes()
        {
            var r = typeBLL.getAllAsync();
            return r;

        }
        [HttpPost]
        public async Task<int> AddType(DTO.Classes.TypeDTO newType)
        {
            return await typeBLL.addAsync(newType);
        }
        [HttpDelete]
        public async Task<bool> DeleteType(int i)
        {
            return await typeBLL.removeAsync(i);
        }
    }
}
