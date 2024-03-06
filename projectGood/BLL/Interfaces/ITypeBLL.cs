using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITypeBLL
    {
        //Task< List<DTO.Classes.TypeDTO>> getAllAsync();
        List<DTO.Classes.TypeDTO> getAllAsync();

        Task<int> addAsync(DTO.Classes.TypeDTO typeDTO );
        Task< bool> removeAsync( int id );
    }
}
