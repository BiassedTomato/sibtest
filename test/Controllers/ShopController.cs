
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

        [HttpPost("addVehicle")]
        public void AddVehicle([FromBody] VehicleDTO vehicle)
        {
            _vehicleService.RegisterVehicle(vehicle);
        }

        [HttpPatch("changeRepairStatus")]
        public void ChangeStatus(Guid repairId, int status)
        {
            _repairService.ChangeRepairStatus(repairId, (RepairStatus)status);
        }

        [HttpGet("repairs")]
        public ActionResult<IEnumerable<Repair>> GetRepairsList([FromQuery] string clientId)
        {
            return Ok(_repairService.GetClientRepairs(clientId));
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
        public ActionResult<ShopReport> GetShopReport(string shopId)
        {
            return Ok(_reportService.BuildShopReport(shopId));
        }
    }
}
