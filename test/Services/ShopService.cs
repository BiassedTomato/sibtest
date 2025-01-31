using System.Linq;

public class ShopService
{
    private readonly AppContext _ctx;

    public ShopService(AppContext ctx)
    {
        _ctx = ctx;
    }

    public Shop RegisterShop(string name, string numberId)
    {
        var shop = new Shop() { Name = name, IdNumber = numberId };
        _ctx.Shops.Add(shop);

        _ctx.SaveChanges();
        return shop;
    }

    public Shop? GetShop(string shopId)
    {
        return _ctx.Shops.FirstOrDefault(x => x.IdNumber == shopId);
    }
}