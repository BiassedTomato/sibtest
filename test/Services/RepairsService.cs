using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class RepairsService
{
    private readonly AppContext _ctx;
    private readonly ClientService _clientService;
    private readonly ShopService _shopService;

    public RepairsService(AppContext ctx, ClientService clientService, ShopService shopService)
    {
        _ctx = ctx;
        _shopService = shopService;
        _clientService = clientService;
    }

    public Repair CreateRepair(string clientId, float cost, float mileage, Guid repairType)
    {
        var client = _clientService.GetClient(clientId, true);

        var repair = new Repair()
        {
            Client = client,
            Cost = cost,
            Mileage = mileage,
            Shop = client.Shop,

            RepairType = _ctx.RepairTypes.First(x => x.Id == repairType)
        };

        _ctx.Repairs.Add(repair);

        _ctx.SaveChanges();

        return repair;
    }

    public IEnumerable<Repair> GetClientRepairs(string clientId)
    {
        return _ctx.Clients.Include(x => x.Repairs).FirstOrDefault(x => x.IdNumber == clientId).Repairs;
    }

    public void ChangeRepairStatus(Guid id, RepairStatus status)
    {
        _ctx.Repairs.First(x => x.Id == id).RepairStatus = status;
        _ctx.SaveChanges();
    }

}