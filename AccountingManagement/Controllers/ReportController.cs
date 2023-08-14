using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using AccountingManagement.Interfaces;

namespace AccountingManagement.Controllers
{
    [ApiController]
    [Route("api/financial-reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IFinancialReportService _financialReportService;

        public ReportsController(IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GenerateFinancialReport(int clientId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (startDate >= endDate)
            {
                return BadRequest("Invalid date range. End date must be after start date.");
            }

            var financialReport = await _financialReportService.GenerateFinancialReportAsync(clientId, startDate, endDate);
            return Ok(financialReport);
        }
    }

}
