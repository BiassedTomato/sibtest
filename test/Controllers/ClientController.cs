
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using LDBModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

        private ReportsService _reportsService;

        public ClientController(ReportsService reports, ILogger<ClientController> logger)
        {
            _logger = logger;

            _reportsService = reports;
        }

        [HttpGet("get")]
        public ClientReport Test([FromQuery] string IdNumber)
        {
            return _reportsService.BuildClientReport(IdNumber);
        }
    }
}
