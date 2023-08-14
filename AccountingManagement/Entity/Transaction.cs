using System;
using AccountingManagement.Common;
using AccountingManagement.Enum;

namespace AccountingManagement.Entity
{
    public class Transaction : BaseEntity
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; } // credit or debit


        public long AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
