using System.Collections.Generic;

public class RepairsReport
{
    public IEnumerable<Repair> Repairs { get; set; }
    public int TotalCount { get; set; }
    public float TotalSum { get; set; }
}
