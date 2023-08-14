using AccountingManagement.Entity;
using AccountingManagement.Enum;
using System;

namespace AccountingManagement.Dto
{
    public class CreateTransactionDto
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; } // credit or debit
        public long AccountId { get; set; }
    }
}
