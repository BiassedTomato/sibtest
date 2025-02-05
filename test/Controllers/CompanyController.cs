
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
			try
			{
				var report = _reportsService.BuildShopReport(idNumber, startDate, endDate);

				if (report == null)
				{
					_logger.LogError($"Не удалось сформировать отчет по сервисам по параметрам: ИНН сервиса {idNumber}, дата начала {startDate}, дата окончания {endDate}.");
					return BadRequest();
				}

				return Ok(report);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Внутренняя ошибка создания отчета для сервиса: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpGet("client")]
		public ActionResult<ClientReport> CreateClientReport([FromQuery] string idNumber, DateTime startDate, DateTime endDate)
		{
			try
			{
				var report = _reportsService.BuildClientReport(idNumber, startDate, endDate);

				if (report == null)
				{
					_logger.LogError($"Не удалось сформировать отчет по клиентам по параметрам: ИНН клиента {idNumber}, дата начала {startDate}, дата окончания {endDate}.");
					return BadRequest();
				}

				return Ok(report);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Внутренняя ошибка создания отчета для клиента: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpGet("repairs")]
		public ActionResult<RepairsReport> CreateRepairsReport([FromQuery] DateTime startDate, DateTime endDate)
		{
			try
			{
				var report = _reportsService.BuildRepairsReport(startDate, endDate);

				if (report == null)
				{
					_logger.LogError($"Не удалось сформировать отчет по услугам по параметрам:дата начала {startDate}, дата окончания {endDate}.");
					return BadRequest();
				}


				return Ok(report);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Внутренняя ошибка создания отчета для услуг: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpGet("vehicle")]
		public ActionResult<VehicleReport> CreateVehicleReport([FromQuery] string idNumber, DateTime startDate, DateTime endDate)
		{
			try
			{
				var report = _reportsService.BuildVehiclesReport(idNumber, startDate, endDate);

				if (report == null)
				{
					_logger.LogError($"Не удалось сформировать отчет по ТС по параметрам: номер ТС {idNumber}, дата начала {startDate}, дата окончания {endDate}.");
					return BadRequest();
				}

				return Ok(report);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Внутренняя ошибка создания отчета для ТС: \n{ex.Message}");
				return StatusCode(500);
			}
		}
	}
}
