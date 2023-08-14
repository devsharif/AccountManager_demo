using System.Threading.Tasks;
using System;
using AccountingManagement.Dto;

namespace AccountingManagement.Interfaces
{
    public interface IFinancialReportService
    {
        Task<FinancialReportDto> GenerateFinancialReportAsync(long clientId, DateTime startDate, DateTime endDate);
    }

}
