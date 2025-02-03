using System;
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

		[HttpGet("report")]
		public ActionResult<ClientReport> GetClientReport([FromQuery] string clientId, DateTime start, DateTime end)
		{
			var report = _reportsService.BuildClientReport(clientId, start, end);

			if (report == null)
			{
				return NotFound($"No client with id {clientId}");
            }

            return Ok(report);
        }
    }
}
