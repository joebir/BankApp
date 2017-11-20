using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class DepositModel
    {
        [Required]
        public int DepositID { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public int TransactionID { get; set; }
    }
}
