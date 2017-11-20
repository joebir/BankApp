using Bank.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class UserService
    {
        private readonly int _userId;

        public UserService(int userId)
        {
            _userId = userId;
        }

        public UserModel GetUserByID(int id)
        {
            using (var ctx = new BankDbContext())
            {
                return
                    ctx
                        .Customers
                        .Where(e => e.CustomerID = _userId);
            }
        }

        public string GetFirstName()
        {

        }

        public string GetLastName()
        {

        }

        public string GetFullName()
        {
            return (GetFirstName() + " " + GetLastName());
        }
    }
}
