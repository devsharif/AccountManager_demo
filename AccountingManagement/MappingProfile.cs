using AccountingManagement.Dto;
using AccountingManagement.Entity;
using AutoMapper;

namespace AccountingManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDto, Account>().ReverseMap();
            CreateMap<CreateAccountDto, Account>().ReverseMap();
            CreateMap<UpdateAccountDto, Account>().ReverseMap();

            CreateMap<TransactionDto, Transaction>().ReverseMap();
            CreateMap<CreateTransactionDto, Transaction>().ReverseMap();
            CreateMap<UpdateTransactionDto, Transaction>().ReverseMap();
        }
    }
}
