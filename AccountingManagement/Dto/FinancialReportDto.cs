using AccountingManagement.Enum;

namespace AccountingManagement.Dto
{
    public class FinancialReportDto
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public ProfitType ProfitType => (TotalIncome > TotalExpenses) ? ProfitType.Profit : ProfitType.Profit;
        public decimal ProfitLossAmount { get; set; }
    }

}
