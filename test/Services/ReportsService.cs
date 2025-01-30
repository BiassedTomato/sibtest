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

    public ShopReport BuildShopReport(string serviceId)
    {
        var service = _ctx.Services.FirstOrDefault(x => x.IdNumber == serviceId);

        if (service == null)
        {
            throw new System.Exception("Not found");
        }

        var repairs = _ctx.Repairs.Where(x => x.Shop == service);

        return new()
        {
            Repairs = repairs,
            TotalCount = repairs.Count(),
            TotalSum = repairs.Sum(x => x.Cost),
        };
    }

    public ClientReport BuildClientReport(string clientId)
    {
        var client = _ctx.Clients.FirstOrDefault(x => x.IdNumber == clientId);

        if (client == null)
        {
            throw new System.Exception("Not found");
        }

        var repairs = _ctx.Repairs.Where(x => x.Client == client);

        return new() { Repairs = repairs, TotalCount = repairs.Count(), TotalSum = repairs.Sum(x => x.Cost) };
    }

    public VehicleReport BuildVehiclesReport(string vehicleId)
    {
        var vehicle = _ctx.Vehicles.FirstOrDefault(x => x.CarNumber == vehicleId);

        if (vehicle == null)
        {
            throw new System.Exception("Not found");
        }

        var repairs = _ctx.Repairs.Where(x => x.Vehicle == vehicle);


        return new() { Repairs = repairs, TotalSum = repairs.Sum(x => x.Cost) };
    }

    public RepairsReport BuildRepairsReport(string serviceId, DateTime start, DateTime end)
    {
        var service = _ctx.Services.FirstOrDefault(x => x.IdNumber == serviceId);

        if (service == null)
        {
            throw new System.Exception("Not found");
        }

        var repairs = _ctx.Repairs.Where(
            x => x.Shop == service &&
                x.FinishedDate != null &&
                x.FinishedDate >= start &&
                x.FinishedDate <= end);

        return new() { Repairs = repairs, TotalCount = repairs.Count(), TotalSum = repairs.Sum(x => x.Cost) };
    }
}