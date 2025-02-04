using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class VehicleService
{
    private readonly AppContext _ctx;
    private readonly ClientService _clientService;

    public VehicleService(AppContext context, ClientService clientService)
    {
        _ctx = context;
        _clientService = clientService;
    }

    public Vehicle RegisterVehicle(VehicleDTO dto)
    {
        var vehicle = new Vehicle() { Owner = _clientService.GetClient(dto.ClientNumber), VehicleNumber = dto.VehicleNumber, Model = dto.Model };

        _ctx.Vehicles.Add(vehicle);

        _ctx.SaveChanges();

        return vehicle;
    }

	public void UpdateVehicle(string numberId, VehicleDTO dto)
	{
		var vehicle = _ctx.Vehicles.First(x => x.VehicleNumber == numberId);

		vehicle.VehicleNumber = dto.VehicleNumber;
		vehicle.Model = dto.Model;

        var client = _ctx.Clients.First(x => x.IdNumber == dto.ClientNumber);

		vehicle.Owner = client;

		_ctx.SaveChanges();
	}

	/// <summary>
	/// Удаление ТС из БД, отвязывается от клиента
	/// </summary>
	/// <param name="idNumber"></param>
	public void DeleteVehicle(string idNumber)
	{
		var vehicle = _ctx.Vehicles.First(x => x.VehicleNumber == idNumber);

		_ctx.Vehicles.Remove(vehicle);

		_ctx.SaveChanges();
	}

	public IEnumerable<VehicleDTO> GetClientVehicles(string idNumber)
	{
		return _ctx.Clients.Include(x => x.Vehicles).First(x => x.IdNumber == idNumber).Vehicles.Select(x => new VehicleDTO()
		{
			ClientNumber = idNumber,
			Model = x.Model,
			VehicleNumber = x.VehicleNumber
		});
	}

	public void RegisterVehicles(IEnumerable<VehicleDTO> vehicles)
    {
        foreach (var vehicleDTO in vehicles)
        {
            var vehicle = new Vehicle() { Owner = _clientService.GetClient(vehicleDTO.ClientNumber), VehicleNumber = vehicleDTO.VehicleNumber, Model = vehicleDTO.Model };
            _ctx.Vehicles.Add(vehicle);
        }

        _ctx.SaveChanges();
    }

    public Vehicle GetVehicle(string number)
    {
        return _ctx.Vehicles.FirstOrDefault(x => x.VehicleNumber == number);
    }
}