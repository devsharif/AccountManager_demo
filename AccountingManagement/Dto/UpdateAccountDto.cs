using AccountingManagement.Enum;
using System;

namespace AccountingManagement.Dto
{
    public class UpdateAccountDto
    {
        public long Id { get; set; }
        public string HolderName { get; set; }
        public AccountType Type { get; set; }
    }
}
