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
        private readonly int _accountId;

        public AccountService(int accountId)
        {
            _accountId = accountId;
        }

        public Account GetAccount()
        {
            using (var ctx = new BankDBEntities())
            {
                var e = ctx.Accounts.Find(_accountId);

                if(e != null)
                {
                    return new Account
                    {
                        AccountID = e.AccountID,
                        AccountNumber = e.AccountNumber,
                        Pin = e.Pin,
                        AccountType = e.AccountType,
                        Balance = e.Balance,
                        CustomerID = e.CustomerID
                    };
                }

                return null;
            }
        }

        public bool Verify(string pin)
        {
            if (pin == GetAccount().Pin) return true;

            return false;
        }

        public int GetUserID()
        {
            return GetAccount().CustomerID;
        }
    }
}
