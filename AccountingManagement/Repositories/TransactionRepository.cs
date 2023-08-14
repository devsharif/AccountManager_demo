using AccountingManagement.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingManagement.Entity;
using AccountingManagement.Data;
using Microsoft.EntityFrameworkCore;
using AccountingManagement.Dto;
using System.Security.Principal;
using AutoMapper;
using System;
using AccountingManagement.Common;
using AccountingManagement.Enum;
using System.Linq;
using System.Drawing;

namespace AccountingManagement.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;

        public TransactionRepository(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TransactionDto> GetByIdAsync(long id)
        {
            var transaction = await _dbContext.Transactions
                .Include(t => t.Account)
                .FirstOrDefaultAsync(t => t.Id == id);

            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<IEnumerable<TransactionDto>> GetAllAsync()
        {
            var transactions = await _dbContext.Transactions
            .Include(t => t.Account)
                .ToListAsync();

            var result = _mapper.Map<List<TransactionDto>>(transactions);
            return result;
        }

        public async Task AddAsync(CreateTransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == transactionDto.AccountId);
            if (transaction.Type == TransactionType.Credit)
            {
                account.Balance += transactionDto.Amount;
            }
            else
            {
                if (account.Balance < transactionDto.Amount) throw new Exception($"Sorry! You don't have Enough Balance [{account.Balance}] for Debit");
                account.Balance -= transactionDto.Amount;
            }

            transaction.Account = account;
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateTransactionDto transaction)
        {
            var existingTransaction = await _dbContext.Transactions.FindAsync(transaction.Id);
            if (existingTransaction == null) throw new NotFoundException($"Transaction with ID {transaction.Id} not found.");

            _mapper.Map(transaction, existingTransaction);

            _dbContext.Transactions.Update(existingTransaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var transaction = await _dbContext.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _dbContext.Transactions.Remove(transaction);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<Transaction>> GetTransactionsByClientAndDateRangeAsync(long clientId, DateTime startDate, DateTime endDate)
        {
            return await _dbContext.Transactions
                .Where(t => t.Account.Id == clientId && t.CreatedDate >= startDate && t.CreatedDate <= endDate)
                .ToListAsync();
        }
    }
}
