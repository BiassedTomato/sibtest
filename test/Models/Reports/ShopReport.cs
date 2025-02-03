using System.Collections.Generic;

public class ShopReport
{
    public string ShopId { get; set; }
    public string ShopName { get; set; }
	public IEnumerable<RepairReportDTO> Repairs { get; set; }
    public int TotalCount { get; set; }
    public float TotalSum { get; set; }
}
