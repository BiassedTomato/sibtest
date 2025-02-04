
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ReportsService reports, ILogger<CompanyController> logger)
        {
            _logger = logger;
            _reportsService = reports;
        }

        private ReportsService _reportsService;

		[HttpGet("shop")]
		public ActionResult<ShopReport> CreateShopReport([FromQuery] string idNumber, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
		{
			var report = _reportsService.BuildShopReport(idNumber, startDate, endDate);

			if (report == null)
			{
				return NotFound();
			}

			return Ok(report);
		}

		[HttpGet("client")]
		public ActionResult<ClientReport> CreateClientReport([FromQuery] string IdNumber, DateTime startDate, DateTime endDate)
		{
			var report = _reportsService.BuildClientReport(IdNumber, startDate, endDate);

			if (report == null)
			{
				return BadRequest();
			}

			return Ok(report);
        }

        [HttpGet("repairs")]
        public ActionResult<RepairsReport> CreateRepairsReport([FromQuery] DateTime startDate, DateTime endDate)
        {
            return Ok(_reportsService.BuildRepairsReport(startDate, endDate));
        }

        [HttpGet("vehicle")]
        public ActionResult<VehicleReport> CreateVehicleReport([FromQuery] string idNumber, DateTime startDate, DateTime endDate)
        {
            return Ok(_reportsService.BuildVehiclesReport(idNumber, startDate, endDate));
        }
    }
}
