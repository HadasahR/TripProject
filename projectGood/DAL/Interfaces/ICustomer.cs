using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface ICustomer
    {
        Task<List<Customer>> getAllAsync();
        Task<Customer> getByMailAndPasswordAsync(string mail,string password);
        Task<int> addAsync(Customer customer);
        Task<bool> deleteAsync(int id);
        Task<bool> updateAsync(Customer customer);

    }
}
