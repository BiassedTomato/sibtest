using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class ReportsService
{
	private AppContext _ctx;
	private ILogger<ReportsService> _logger;
	public ReportsService(AppContext ctx, ILogger<ReportsService> logger)
	{
		_ctx = ctx;
		_logger = logger;
	}

	public ShopReport BuildShopReport(string shopNumber, DateTime start, DateTime end)
	{
		var shop = _ctx.Shops
			.AsNoTracking()
			.Include(x => x.Repairs).ThenInclude(x => x.Vehicle)
			.Include(x => x.Repairs).ThenInclude(x => x.Client)
			.Include(x => x.Repairs).ThenInclude(x => x.RepairType)
			.FirstOrDefault(x => x.IdNumber == shopNumber);

		if (shop == null)
		{
			_logger.LogError($"Не найден магазин с ИНН {shopNumber}");
			return null;
		}

		var repairs = shop.Repairs
			.Where(x =>
				x.RepairStatus == RepairStatus.Finished &&
				x.FinishedDate != null &&
				x.FinishedDate >= start &&
				x.FinishedDate <= end)
			.Select(x => new RepairReportDTO()
			{
				ClientId = x.Client.IdNumber,
				ClientName = $"{x.Client.FirstName} {x.Client.LastName}",
				Cost = x.RepairType.Cost,
				FinishedDate = x.FinishedDate.Value,
				ServiceType = x.RepairType.Name,
				//VehicleMileage = x.Vehicle.,
				VehicleModel = x.Vehicle.Model,
				VehicleNumber = x.Vehicle.VehicleNumber,
			})
			.ToList();

		return new()
		{
			ShopId = shopNumber,
			ShopName = shop.Name,
			Repairs = repairs,
			TotalCount = repairs.Count(),
			TotalSum = repairs.Sum(x => x.Cost),
		};
	}

	public ClientReport BuildClientReport(string clientNumber, DateTime start, DateTime end)
	{
		var client = _ctx.Clients.FirstOrDefault(x => x.IdNumber == clientNumber);

		if (client == null)
		{
			return null;
		}

		var repairs = _ctx.Repairs
			.Where(
			x => x.Client == client &&
			x.FinishedDate != null &&
			x.FinishedDate >= start &&
			x.FinishedDate <= end)
			.Select(x => new RepairReportDTO()
			{
				ClientId = client.IdNumber,
				ClientName = $"{client.FirstName} {client.LastName}",
				Cost = x.RepairType.Cost,
				FinishedDate = x.FinishedDate.Value,
				ServiceType = x.RepairType.Name,
				VehicleModel = x.Vehicle.Model,
				VehicleNumber = x.Vehicle.VehicleNumber,
			});

		return new() { ClientId = client.IdNumber, ClientName = $"{client.FirstName} {client.LastName}", Repairs = repairs, TotalCount = repairs.Count(), TotalSum = repairs.Sum(x => x.Cost) };
	}

	public VehicleReport BuildVehiclesReport(string vehicleNumber, DateTime start, DateTime end)
	{
		var vehicle = _ctx.Vehicles.Include(x => x.Owner).FirstOrDefault(x => x.VehicleNumber == vehicleNumber);

		if (vehicle == null)
		{
			return null;
		}

		var client = vehicle.Owner;

		var allRepairs = _ctx.Repairs.ToList();

		var repairs = _ctx.Repairs
			.Where(
			x => x.Vehicle == vehicle &&
			x.FinishedDate != null &&
			x.FinishedDate >= start &&
			x.FinishedDate <= end)
			.Select(x => new RepairReportDTO()
			{
				ClientId = client.IdNumber,
				ClientName = $"{client.FirstName} {client.LastName}",
				Cost = x.RepairType.Cost,
				FinishedDate = x.FinishedDate.Value,
				ServiceType = x.RepairType.Name,
				VehicleModel = x.Vehicle.Model,
				VehicleNumber = x.Vehicle.VehicleNumber,
			}).ToList();


		return new() { VehicleModel = vehicle.Model, VehicleNumber = vehicle.VehicleNumber, TotalCount = repairs.Count(), Repairs = repairs, TotalSum = repairs.Sum(x => x.Cost) };
	}

	public RepairsReport BuildRepairsReport(DateTime start, DateTime end)
	{
		var repairs = _ctx.Repairs.Include(x => x.Client).Include(x=>x.Shop).Where(
			x =>
				x.FinishedDate != null &&
				x.FinishedDate >= start &&
				x.FinishedDate <= end)
			.Select(x => new RepairReportDTO()
			{
				ClientId = x.Client.IdNumber,
				ClientName = $"{x.Client.FirstName} {x.Client.LastName}",
				ShopId=x.Shop.IdNumber,
				ShopName=x.Shop.Name,
				Cost = x.RepairType.Cost,
				FinishedDate = x.FinishedDate.Value,
				ServiceType = x.RepairType.Name,
				VehicleModel = x.Vehicle.Model,
				VehicleNumber = x.Vehicle.VehicleNumber,
			});

		return new() { Repairs = repairs, TotalCount = repairs.Count(), TotalSum = repairs.Sum(x => x.Cost) };
	}
}