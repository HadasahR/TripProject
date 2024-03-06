using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class Type : ITypes
    {
        IContext db;
        public Type(IContext db)
        {
            this.db = db;
            
        }
        public async Task<int> addAsync(Models.Type type)
        {
            try
            {
                db.Types.Add(type);
                await db.SaveChangesAsync();

                return db.Types.Count();
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
                db.Types.Remove(db.Types.FirstOrDefault(u=>u.TypeId==id));
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public  List<Models.Type> getAllAsync()
        {
            var r =  db.Types.ToList();
            return r;
             }
        public  async Task<Models.Type> getByIdAsync(int id)
        {
            var type = await db.Types.FirstOrDefaultAsync(p => p.TypeId == id);
            return type;
        }
    }
}
