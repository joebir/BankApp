using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    class DepositService
    {
        public bool Deposit(decimal amount, Account account)
        {
            using (var ctx = new BankDBEntities())
            {
                var transaction =
                    new Transaction
                    {
                        TransactionType = "Deposit",
                        AccountID = account.AccountID
                    };
                ctx.Transactions.Add(transaction);

                var deposit =
                    new Deposit
                    {
                        Amount = amount,
                    };
                ctx.Deposits.Add(deposit);

                account.Balance += amount;

                return ctx.SaveChanges() == 3;
            }
        }
    }
}
