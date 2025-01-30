using System.Collections.Generic;

public class ClientReport
{
    public IEnumerable<Repair> Repairs { get; set; }
    public int TotalCount { get; set; }
    public float TotalSum { get; set; }
}

public class ServiceReport
{
    public IEnumerable<Repair> Repairs { get; set; }
    public int TotalCount { get; set; }
    public float TotalSum { get; set; }

}

public class RepairsReport
{
    public IEnumerable<Repair> Repairs { get; set; }
    public int TotalCount { get; set; }
    public float TotalSum { get; set; }
}

public class VehicleReport
{
    public IEnumerable<Repair> Repairs { get; set; }
    public int TotalCount { get; set; }
    public float TotalSum { get; set; }

    public float MileageDelta { get; set; }
}