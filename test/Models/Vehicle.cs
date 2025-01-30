using System;

public class Vehicle
{
    public Guid Id { get; set; }
    public Client Owner { get; set; }

    /// <summary>
    /// Номер формата "A123BC"
    /// </summary>
    public string CarNumber { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
}