
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace test.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ShopController : ControllerBase
	{
		private readonly ILogger<ShopController> _logger;
		private readonly ClientService _clientService;
		private readonly VehicleService _vehicleService;
		private readonly ReportsService _reportService;
		private readonly RepairsService _repairService;

		public ShopController(ClientService clientService, VehicleService vehicleService, ReportsService reportsService, RepairsService repairsService, ILogger<ShopController> logger)
		{
			_logger = logger;
			_clientService = clientService;
			_vehicleService = vehicleService;
			_reportService = reportsService;
			_repairService = repairsService;
		}

		[HttpPost("registerClient")]
		public IActionResult RegisterClient([FromBody] ClientRegisterDTO register)
		{
			try
			{
				_clientService.CreateClient(register.FirstName, register.LastName, register.ClientNumber, register.ShopNumber);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Не удалось зарегистрировать клиента ({register}): \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpPost("addVehicles")]
		public IActionResult AddVehicles([FromBody] IEnumerable<VehicleDTO> vehicles)
		{
			try
			{
				_vehicleService.RegisterVehicles(vehicles);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Не удалось добавить несколько транспортных средств: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpPost("createRepair")]
		public IActionResult CreateRepair(RepairDTO repair)
		{
			try
			{
				var nRepair = _repairService.CreateRepair(repair.ClientNumber, repair.VehicleNumber, repair.Cost, repair.Mileage, repair.RepairType);

				if (nRepair != null)
				{
					return Ok();

				}
				return BadRequest();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Не удалось создать услугу: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpPost("addVehicle")]
		public IActionResult AddVehicle([FromBody] VehicleDTO vehicle)
		{
			try
			{
				_vehicleService.RegisterVehicle(vehicle);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Не удалось добавить ТС: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpGet("getRepairTypes")]
		public IActionResult GetRepairTypes()
		{
			try
			{
				return Ok(_repairService.GetRepairTypes());
			}
			catch (Exception ex)
			{
				_logger.LogError($"Не удалось получить список типов услуг: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpPatch("changeRepairStatus")]
		public IActionResult ChangeStatus(Guid repairId, int status)
		{
			try
			{
				if (status == (int)RepairStatus.Cancelled || status == (int)RepairStatus.Finished)
				{
					_repairService.FinishRepair(repairId, (RepairStatus)status);
				}
				else
				{
					_repairService.ChangeRepairStatus(repairId, (RepairStatus)status);
				}
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Не удалось обновить статус услуги: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpGet("repairs")]
		public IActionResult GetRepairsList([FromQuery] string clientId)
		{
			try
			{
				return Ok(_repairService.GetClientRepairs(clientId));
			}
			catch (Exception ex)
			{
				_logger.LogError($"Не удалось получить список услуг: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpGet("vehicles")]
		public IActionResult GetVehiclesList([FromQuery] string clientId)
		{
			try
			{
				return Ok(_vehicleService.GetClientVehicles(clientId));
			}
			catch (Exception ex)
			{
				_logger.LogError($"Не удалось получить список ТС: \n{ex.Message}");
				return StatusCode(500);
			}
		}

		[HttpGet("report")]
		public IActionResult GetShopReport([FromQuery] string shopId, DateTime start, DateTime end)
		{
			try
			{
				return Ok(_reportService.BuildShopReport(shopId, start, end));
			}
			catch (Exception ex)
			{
				_logger.LogError($"Не удалось сформировать отчет по магазину: \n{ex.Message}");
				return StatusCode(500);
			}
		}
	}
}
