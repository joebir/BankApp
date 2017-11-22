using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class AccountService
    {
        public Account GetAccount(string accountId)
        {
            int id = Int32.Parse(accountId);
            using (var ctx = new BankDBEntities())
            {
                return ctx
                    .Accounts
                    .SingleOrDefault(e => e.AccountID == id);
            }
        }
    }
}
