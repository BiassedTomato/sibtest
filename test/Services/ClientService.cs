using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class ClientService
{
    private readonly AppContext _ctx;
    private readonly ShopService _shopService;
    public ClientService(AppContext ctx, ShopService shopService)
    {
        _ctx = ctx;
        _shopService = shopService;
    }

    public Client? GetClient(string clientNumber, bool includeShop = false)
    {
        var clients = _ctx.Clients;

        if (includeShop)
        {
            return clients.Include(x => x.Shop).FirstOrDefault(x => x.IdNumber == clientNumber);
        }

        return clients.FirstOrDefault(x => x.IdNumber == clientNumber);
    }

    public Client CreateClient(string firstName, string lastName, string idNumber, string shopId)
    {
        var client = new Client() { FirstName = firstName, LastName = lastName, IdNumber = idNumber, Shop = _shopService.GetShop(shopId) };

        _ctx.Clients.Add(client);
        _ctx.SaveChanges();

        return client;
    }



    public IEnumerable<Client>? GetShopClients(string shopId)
    {
        return _ctx.Shops.Include(x => x.Clients).FirstOrDefault(x => x.IdNumber == shopId).Clients;
    }
}