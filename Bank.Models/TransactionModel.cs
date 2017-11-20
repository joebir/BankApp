using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class TransactionModel
    {
        [Required]
        public int TransactionID { get; set; }

        [Required]
        [MaxLength(10)]
        public string TransactionType { get; set; }

        [Required]
        public int AccountID { get; set; }
    }
}
