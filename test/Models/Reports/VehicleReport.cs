using System.Collections.Generic;

public class VehicleReport
{
    public IEnumerable<Repair> Repairs { get; set; }
    public int TotalCount { get; set; }
    public float TotalSum { get; set; }

    public float MileageDelta { get; set; }
}