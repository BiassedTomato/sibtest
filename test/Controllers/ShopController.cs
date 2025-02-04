
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

		[HttpPost("registerClient")]
		public void RegisterClient([FromBody] ClientRegisterDTO register)
		{
			_clientService.CreateClient(register.FirstName, register.LastName, register.ClientNumber, register.ShopNumber);
		}

		[HttpPost("addVehicles")]
		public void AddVehicles([FromBody] IEnumerable<VehicleDTO> vehicles)
		{
			_vehicleService.RegisterVehicles(vehicles);
		}

		[HttpPost("createRepair")]
		public ActionResult<Repair> CreateRepair(RepairDTO repair)
		{
			var nRepair = _repairService.CreateRepair(repair.ClientNumber, repair.VehicleNumber, repair.Cost, repair.Mileage, repair.RepairType);

			if (nRepair != null)
			{
				return Ok();

			}
			return BadRequest();
		}

		[HttpPost("addVehicle")]
		public void AddVehicle([FromBody] VehicleDTO vehicle)
		{
			_vehicleService.RegisterVehicle(vehicle);
		}

		[HttpGet("getRepairTypes")]
		public ActionResult GetRepairTypes()
		{
			return Ok(_repairService.GetRepairTypes());
		}

		[HttpPatch("changeRepairStatus")]
		public void ChangeStatus(Guid repairId, int status)
		{
			if (status == (int)RepairStatus.Cancelled || status == (int)RepairStatus.Finished)
			{
				_repairService.FinishRepair(repairId, (RepairStatus)status);
			}
			else
			{
				_repairService.ChangeRepairStatus(repairId, (RepairStatus)status);
			}
		}

		[HttpGet("repairs")]
		public ActionResult<IEnumerable<RepairDTO>> GetRepairsList([FromQuery] string clientId)
		{
			return Ok(_repairService.GetClientRepairs(clientId));
		}

		[HttpGet("vehicles")]
		public ActionResult<IEnumerable<VehicleDTO>> GetVehiclesList([FromQuery] string clientId)
		{
			return Ok(_vehicleService.GetClientVehicles(clientId));
		}

		public ShopController(ClientService clientService, VehicleService vehicleService, ReportsService reportsService, RepairsService repairsService, ILogger<ShopController> logger)
		{
			_logger = logger;
			_clientService = clientService;
			_vehicleService = vehicleService;
			_reportService = reportsService;
			_repairService = repairsService;
		}

		[HttpGet("report")]
		public ActionResult<ShopReport> GetShopReport([FromQuery]string shopId, DateTime start, DateTime end)
		{
			return Ok(_reportService.BuildShopReport(shopId, start, end));
		}
	}
}
