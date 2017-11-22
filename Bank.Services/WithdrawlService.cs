using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class WithdrawlService
    {
        public bool Withdraw(decimal amount, Account account)
        {
            using (var ctx = new BankDBEntities())
            {
                var transaction =
                    new Transaction
                    {
                        TransactionType = "Withdrawl",
                        AccountID = account.AccountID
                    };
                ctx.Transactions.Add(transaction);

                var withdrawl =
                    new Withdrawl
                    {
                        Amount = amount,
                    };
                ctx.Withdrawls.Add(withdrawl);

                ctx.Accounts.SingleOrDefault(e => e.AccountID == account.AccountID).Balance -= amount;
                account.Balance -= amount;

                return ctx.SaveChanges() == 3;
            }
        }
    }
}
