using AccountingManagement.Enum;
using System;

namespace AccountingManagement.Dto
{
    public class AccountDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
