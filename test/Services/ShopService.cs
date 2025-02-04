using System.Linq;
using Microsoft.EntityFrameworkCore;

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

	/// <summary>
	/// ��������� ������ ��������
	/// </summary>
	/// <param name="oldIdNumber">������ ���</param>
	/// <param name="newNumber">����� ���</param>
	/// <param name="name">������������</param>
	public void UpdateShop(string oldIdNumber, ShopDTO dto)
	{
		var shop = _ctx.Shops.First(x => x.IdNumber == oldIdNumber);

		shop.IdNumber = dto.ShopId;
		shop.Name = dto.Name;

		_ctx.SaveChanges();
	}

	/// <summary>
	/// �������� ��� �� ��
	/// </summary>
	/// <param name="idNumber"></param>
	public void DeleteShop(string idNumber)
	{
		var shop = _ctx.Shops.First(x => x.IdNumber == idNumber);

		_ctx.Shops.Remove(shop);

		_ctx.SaveChanges();
	}

	public Shop? GetShop(string shopId)
    {
        return _ctx.Shops.FirstOrDefault(x => x.IdNumber == shopId);
    }
}