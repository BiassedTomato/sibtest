using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class RepairsService
{
    private readonly AppContext _ctx;
    private readonly ClientService _clientService;

    public RepairsService(AppContext ctx, ClientService clientService, ShopService shopService)
    {
        _ctx = ctx;
        _clientService = clientService;
	}

	public Repair CreateRepair(string clientId, string vehicleNumber, float cost, float mileage, Guid repairType)
	{
		var client = _clientService.GetClient(clientId, true);

		var repair = new Repair()
		{
			Client = client,
			Cost = cost,
			Mileage = mileage,
			Shop = client.Shop,
			Vehicle = _ctx.Vehicles.FirstOrDefault(x => x.VehicleNumber == vehicleNumber),

			RepairType = _ctx.RepairTypes.First(x => x.Id == repairType)
		};

		_ctx.Repairs.Add(repair);

        _ctx.SaveChanges();

        return repair;
    }

    public void FinishRepair(Guid repairId, RepairStatus status)
    {
        var repair=_ctx.Repairs.FirstOrDefault(x=>x.Id == repairId);

        repair.FinishedDate = DateTime.Now.Date;
		repair.RepairStatus = status;

		_ctx.SaveChanges();
    }

    public Repair GetRepair(Guid id)
    {
        return _ctx.Repairs.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Полностью удаляет запись о ремонте из базы. В общем случае ремонт должен закрываться с нужным статусом а не удаляться.
    /// </summary>
    /// <param name="id"></param>
	public void DeleteRepair(Guid id)
	{
		var repair = _ctx.Repairs.First(x => x.Id == id);

		_ctx.Repairs.Remove(repair);

		_ctx.SaveChanges();
	}

	public IEnumerable<RepairDTO> GetClientRepairs(string clientId)
	{
		var client = _ctx.Clients.First(x=>x.IdNumber== clientId);

		return _ctx.Repairs.Include(x => x.Client).Include(x=>x.Vehicle).Where(x => x.Client == client).Select(x=>new RepairDTO()
		{
			Id=x.Id,
			ClientNumber=x.Client.IdNumber,
			Cost=x.Cost,
			RepairType=x.RepairType.Id,
			RepairTypeName=x.RepairType.Name,
			VehicleNumber=x.Vehicle.VehicleNumber,
		});
	}

	public IEnumerable<RepairType> GetRepairTypes()
	{
		return _ctx.RepairTypes;
	}

    public void ChangeRepairStatus(Guid id, RepairStatus status)
    {
        _ctx.Repairs.First(x => x.Id == id).RepairStatus = status;
        _ctx.SaveChanges();
    }
}