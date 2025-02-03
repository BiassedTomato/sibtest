using System.Collections.Generic;

public class ClientReport
{
    public IEnumerable<Repair> Repairs { get; set; }
    public int TotalCount { get; set; }
    public float TotalSum { get; set; }
}
