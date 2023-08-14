using AccountingManagement.Interfaces;
using System.Threading.Tasks;
using System;
using System.Linq;
using AccountingManagement.Dto;
using AccountingManagement.Enum;

namespace AccountingManagement.Repositories
{
    public class FinancialReportService : IFinancialReportService
    {
        private readonly ITransactionRepository _transactionRepository;

        public FinancialReportService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<FinancialReportDto> GenerateFinancialReportAsync(long clientId, DateTime startDate, DateTime endDate)
        {
            var transactions = await _transactionRepository.GetTransactionsByClientAndDateRangeAsync(clientId, startDate, endDate);

            decimal totalIncome = transactions.Where(t => t.Type == TransactionType.Credit).Sum(t => t.Amount);
            decimal totalExpenses = transactions.Where(t => t.Type == TransactionType.Debit).Sum(t => t.Amount);
            decimal profitLoss = totalIncome - totalExpenses;


            return new FinancialReportDto
            {
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                ProfitLossAmount = profitLoss
            };
        }
    }

}
