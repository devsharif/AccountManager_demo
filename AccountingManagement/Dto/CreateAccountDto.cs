using AccountingManagement.Enum;
using System;

namespace AccountingManagement.Dto
{
    public class CreateAccountDto
    {
        public string HolderName { get; set; }
        public AccountType Type { get; set; }
    }
}
