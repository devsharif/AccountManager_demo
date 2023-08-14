using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingManagement.Dto;
using AccountingManagement.Entity;

namespace AccountingManagement.Interfaces
{
    public interface ITransactionRepository
    {
        Task<TransactionDto> GetByIdAsync(long id);
        Task<IEnumerable<TransactionDto>> GetAllAsync();
        Task AddAsync(CreateTransactionDto transaction);
        Task UpdateAsync(UpdateTransactionDto transaction);
        Task DeleteAsync(long id);

        Task<IEnumerable<Transaction>> GetTransactionsByClientAndDateRangeAsync(long clientId, DateTime startDate, DateTime endDate);
    }

}
