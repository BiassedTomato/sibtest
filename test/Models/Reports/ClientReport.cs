using System.Collections.Generic;

public class ClientReport
{
	public string ClientId { get; set; }
	public string ClientName { get; set; }
	public IEnumerable<RepairReportDTO> Repairs { get; set; }
	public int TotalCount { get; set; }
	public float TotalSum { get; set; }
}
