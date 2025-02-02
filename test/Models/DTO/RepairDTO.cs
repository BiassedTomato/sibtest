using System;

public class RepairDTO
{
    public string ClientNumber { get; set; }
    public float Cost { get; set; }
    public string ShopNumber { get; set; }
    public string VehicleNumber { get; set; }
    public float Mileage { get; set; }
    public Guid RepairType { get; set; }
}
