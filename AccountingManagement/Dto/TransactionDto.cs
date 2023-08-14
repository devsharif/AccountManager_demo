using AccountingManagement.Entity;
using AccountingManagement.Enum;
using System;

namespace AccountingManagement.Dto
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; } // credit or debit
        public DateTime? CreatedDate { get; set; }

        public long AccountId { get; set; }
        public string AccountCode { get; set; }
        public string AccountHolderName { get; set; }
        public decimal AccountBalance { get; set; }
        public AccountType AccountType { get; set; }
    }
}
