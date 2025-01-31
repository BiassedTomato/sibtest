using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class VehicleService
{
    private readonly AppContext _context;
    private readonly ClientService _clientService;

    public VehicleService(AppContext context, ClientService clientService)
    {
        _context = context;
        _clientService = clientService;
    }

    public Vehicle RegisterVehicle(VehicleDTO dto)
    {
        var vehicle = new Vehicle() { Owner = _clientService.GetClient(dto.OwnerId), VehicleNumber = dto.VehicleNumber, Model = dto.Model };

        _context.Vehicles.Add(vehicle);

        _context.SaveChanges();

        return vehicle;
    }

    public void RegisterVehicles(IEnumerable<VehicleDTO> vehicles)
    {
        foreach (var vehicleDTO in vehicles)
        {
            var vehicle = new Vehicle() { Owner = _clientService.GetClient(vehicleDTO.OwnerId), VehicleNumber = vehicleDTO.VehicleNumber, Model = vehicleDTO.Model };
            _context.Vehicles.Add(vehicle);
        }

        _context.SaveChanges();
    }

    public Vehicle GetVehicle(string number)
    {
        return _context.Vehicles.FirstOrDefault(x => x.VehicleNumber == number);
    }
}