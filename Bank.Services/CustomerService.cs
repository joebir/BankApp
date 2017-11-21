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
        private readonly int _customerId;

        public CustomerService(int customerId)
        {
            _customerId = customerId;
        }

        public Customer GetCustomer()
        {
            using (var ctx = new BankDBEntities())
            {
                var e = ctx.Customers.Find(_customerId);

                if(e != null)
                    return new Customer
                    {
                        CustomerID = e.CustomerID,
                        FirstName = e.FirstName,
                        LastName = e.LastName
                    };
                return null;
            }
        }

        public string GetFirstName()
        {
            return GetCustomer().FirstName;
        }

        public string GetLastName()
        {
            return GetCustomer().LastName;
        }

        public string GetFullName()
        {
            return (GetFirstName() + " " + GetLastName());
        }
    }
}
