using System;

public class Vehicle
{
    public Guid Id { get; set; }
    public Client Owner { get; set; }

    /// <summary>
    /// Номер формата "A123BC"
    /// </summary>
    public string VehicleNumber { get; set; }
    public string Model { get; set; }
}