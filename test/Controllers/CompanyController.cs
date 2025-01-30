
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
        public ShopReport CreateShopReport([FromQuery] string IdNumber)
        {
            return _reportsService.BuildShopReport(IdNumber);
        }
        [HttpGet("client")]
        public ClientReport CreateClientReport([FromQuery] string IdNumber)
        {
            return _reportsService.BuildClientReport(IdNumber);
        }
        [HttpGet("repairs")]
        public RepairsReport CreateRepairsReport([FromBody] string IdNumber, DateTime start, DateTime end)
        {
            return _reportsService.BuildRepairsReport(IdNumber, start, end);
        }
        [HttpGet("vehicle")]
        public VehicleReport CreateVehicleReport([FromQuery] string idNumber)
        {
            return _reportsService.BuildVehiclesReport(idNumber);
        }
    }
}
