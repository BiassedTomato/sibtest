
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
        public ActionResult<ShopReport> CreateShopReport([FromQuery] string IdNumber)
        {
            return Ok(_reportsService.BuildShopReport(IdNumber));
        }

        [HttpGet("client")]
        public ActionResult<ClientReport> CreateClientReport([FromQuery] string IdNumber)
        {
            var report = _reportsService.BuildClientReport(IdNumber);

            if (report == null)
            {
                return BadRequest();
            }

            return Ok(report);
        }

        [HttpGet("repairs")]
        public ActionResult<RepairsReport> CreateRepairsReport([FromBody] string IdNumber, DateTime start, DateTime end)
        {
            return Ok(_reportsService.BuildRepairsReport(IdNumber, start, end));
        }
        [HttpGet("vehicle")]
        public ActionResult<VehicleReport> CreateVehicleReport([FromQuery] string idNumber)
        {
            return Ok(_reportsService.BuildVehiclesReport(idNumber));
        }
    }
}
