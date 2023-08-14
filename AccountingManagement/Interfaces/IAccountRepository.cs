using AccountingManagement.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingManagement.Dto;

namespace AccountingManagement.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountDto> GetByIdAsync(long id);
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task AddAsync(CreateAccountDto accountDto);
        Task UpdateAsync(UpdateAccountDto account);
        Task DeleteAsync(long id);
    }

}
