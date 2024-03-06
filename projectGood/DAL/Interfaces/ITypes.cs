using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITypes
    {
       // Task<List<DAL.Models.Type>> getAllAsync();
       List<DAL.Models.Type> getAllAsync();
       Task< Models.Type> getByIdAsync(int id);
       Task< int> addAsync(Models.Type type);
        Task<bool> deleteAsync(int id);

    }
}
