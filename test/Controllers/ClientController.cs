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
		private readonly ReportsService _reportsService;

		public ClientController(ReportsService reports, ILogger<ClientController> logger)
		{
			_logger = logger;

			_reportsService = reports;
		}

		[HttpGet("report")]
		public ActionResult<ClientReport> GetClientReport([FromQuery] string clientId, DateTime startDate, DateTime endDate)
		{
			try
			{
				var report = _reportsService.BuildClientReport(clientId, startDate, endDate);

				if (report == null)
				{
					_logger.LogError($"�� ������� ������������ ����� �� ������� ����������: ��� ������� {clientId}, ���� ������ {startDate}, ���� ��������� {endDate}.");
					return BadRequest();
				}

				return Ok(report);
			}
			catch (Exception ex)
			{
				_logger.LogError($"���������� ������ �������� ������ ��� �������:\n {ex.Message}");
				return StatusCode(500);
			}
		}
	}
}
