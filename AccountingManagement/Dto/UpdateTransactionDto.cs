using AccountingManagement.Entity;
using AccountingManagement.Enum;
using System;

namespace AccountingManagement.Dto
{
    public class UpdateTransactionDto
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; } // credit or debit
        public long AccountId { get; set; }
    }
}
