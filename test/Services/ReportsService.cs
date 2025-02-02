using System;
using System.Linq;
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

    public ShopReport BuildShopReport(string shopNumber)
    {
        var service = _ctx.Shops.FirstOrDefault(x => x.IdNumber == shopNumber);

        if (service == null)
        {
            return null;
        }

        var repairs = _ctx.Repairs.Where(x => x.Shop == service).ToList();

        return new()
        {
            Repairs = repairs,
            TotalCount = repairs.Count(),
            TotalSum = repairs.Sum(x => x.Cost),
        };
    }

    public ClientReport BuildClientReport(string clientNumber)
    {
        var client = _ctx.Clients.FirstOrDefault(x => x.IdNumber == clientNumber);

        if (client == null)
        {
            return null;
        }

        var repairs = _ctx.Repairs.Where(x => x.Client == client);

        return new() { Repairs = repairs, TotalCount = repairs.Count(), TotalSum = repairs.Sum(x => x.Cost) };
    }

    public VehicleReport BuildVehiclesReport(string vehicleNumber)
    {
        var vehicle = _ctx.Vehicles.FirstOrDefault(x => x.VehicleNumber == vehicleNumber);

        if (vehicle == null)
        {
            return null;
        }

        var repairs = _ctx.Repairs.Where(x => x.Vehicle == vehicle);


        return new() { Repairs = repairs, TotalSum = repairs.Sum(x => x.Cost) };
    }

    public RepairsReport BuildRepairsReport(string shopNumber, DateTime start, DateTime end)
    {
        var service = _ctx.Shops.FirstOrDefault(x => x.IdNumber == shopNumber);

        if (service == null)
        {
            return null;
        }

        var repairs = _ctx.Repairs.Where(
            x => x.Shop == service &&
                x.FinishedDate != null &&
                x.FinishedDate >= start &&
                x.FinishedDate <= end)
        .ToList();

        return new() { Repairs = repairs, TotalCount = repairs.Count(), TotalSum = repairs.Sum(x => x.Cost) };
    }
}