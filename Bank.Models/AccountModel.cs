using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class AccountModel
    {
        [Required]
        public int AccountID { get; set; }

        [Required]
        public int AccountNumber { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Pin { get; set; }

        [Required]
        public string AccountType { get; set; }

        [Required]
        public double Balance { get; set; }

        [Required]
        public int CustomerID { get; set; }
    }
}
