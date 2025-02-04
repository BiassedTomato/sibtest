using System;

public class RepairReportDTO
{
    public string ClientName { get; set; }
    public string ClientId { get; set; }
    public string ServiceType { get; set; }
    public string ShopName { get; set; }
    public string ShopId { get; set; }
    public float Cost { get; set; }
    public string VehicleModel { get; set; }
    public string VehicleMileage { get; set; }
    public string VehicleNumber { get; set; }
    public DateTime FinishedDate { get; set; }
}
