//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bank.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Withdrawl
    {
        public int WithdrawlID { get; set; }
        public decimal Amount { get; set; }
        public int TransactionID { get; set; }
    
        public virtual Transaction Transaction { get; set; }
    }
}
