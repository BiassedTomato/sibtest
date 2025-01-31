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

    public Repair CreateRepair(string clientId, float cost, string shopId, Guid repairType)
    {
        var repair = new Repair()
        {
            Client = _clientService.GetClient(clientId),
            Cost = cost,
            Shop = _shopService.GetShop(shopId),
        };
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