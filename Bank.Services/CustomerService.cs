using Bank.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class CustomerService
    {
        public Customer GetCustomer(int customerId)
        {
            using (var ctx = new BankDBEntities())
            {
                return ctx
                    .Customers
                    .SingleOrDefault(e => e.CustomerID == customerId);
            }
        }

        public bool Verify(string pin, Customer customer)
        {
            if (pin == customer.Pin) return true;

            return false;
        }
    }
}
