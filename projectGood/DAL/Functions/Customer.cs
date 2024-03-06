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
    public class Customer : ICustomer
    {
        IContext db;
        public Customer(IContext db)
        {
            this.db = db;
        }

        public async Task<int> addAsync(Models.Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return db.Customers.Count();
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
                db.Customers.Remove(db.Customers.FirstOrDefault(u=>u.CustId==id));
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Models.Customer>> getAllAsync()
        {
              return await db.Customers.ToListAsync();

        }

        public   Task<Models.Customer> getByMailAndPasswordAsync(string mail, string password)
        {
            var customer = db.Customers.FirstAsync(e => e.CustPassword == password && e.CustEmail == mail);
            return customer;
        }

        //עדכון
        public async Task<bool> updateAsync(Models.Customer customer)
        {
            try
            {
                var customerToUpdate = await getByMailAndPasswordAsync(customer.CustEmail,customer.CustPassword);
                if (customerToUpdate == null)
                {
                    //  logger.LogError("the id  does not exist");
                    return false;
                }
                customerToUpdate.CustLname = customer.CustLname;
                customerToUpdate.CustFname = customer.CustFname;
                customerToUpdate.CustEmail = customer.CustEmail;
                customerToUpdate.CustPhone = customer.CustPhone;
                customerToUpdate.CustPassword = customer.CustPassword;
                customerToUpdate.FirstAid = customer.FirstAid;
                //
                customerToUpdate.OrderTickets = customer.OrderTickets;

                db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

