using AccountingManagement.Data;
using AccountingManagement.Entity;
using AccountingManagement.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountingManagement.Dto;
using System.Drawing;
using AutoMapper.QueryableExtensions;
using System.Security.Principal;
using AccountingManagement.Common;

public class AccountRepository : IAccountRepository
{
    private readonly DataContext _dbContext;
    private readonly IMapper _mapper;
    public AccountRepository(DataContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<AccountDto> GetByIdAsync(long id)
    {
        var account = await _dbContext.Accounts
            .Include(a => a.Transactions)
            .FirstOrDefaultAsync(a => a.Id == id);

        return _mapper.Map<AccountDto>(account);
    }

    public async Task<IEnumerable<AccountDto>> GetAllAsync()
    {
        var account = await _dbContext.Accounts.ToListAsync();
        var result = _mapper.Map<List<AccountDto>>(account);
        return result;
    }

    public async Task AddAsync(CreateAccountDto accountDto)
    {
        var account = _mapper.Map<Account>(accountDto);
        _dbContext.Accounts.Add(account);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(UpdateAccountDto account)
    {
        var existingAccount = await _dbContext.Accounts.FindAsync(account.Id);
        if (existingAccount == null) throw new NotFoundException($"Accounts with ID {account.Id} not found.");

        _mapper.Map(account, existingAccount);

        _dbContext.Accounts.Update(existingAccount);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var account = await _dbContext.Accounts.FindAsync(id);
        if (account != null)
        {
            _dbContext.Accounts.Remove(account);
            await _dbContext.SaveChangesAsync();
        }
    }
}