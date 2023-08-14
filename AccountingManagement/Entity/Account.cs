using System.Collections.Generic;
using System;
using AccountingManagement.Common;
using AccountingManagement.Enum;

namespace AccountingManagement.Entity
{
    public class Account : BaseEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}