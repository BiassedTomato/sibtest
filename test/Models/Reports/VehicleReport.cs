using System.Collections.Generic;

public class VehicleReport
{
	public string VehicleNumber { get; set; }
	public string VehicleModel { get; set; }
	public IEnumerable<RepairReportDTO> Repairs { get; set; }
	public int TotalCount { get; set; }
	public float TotalSum { get; set; }
	public float MileageDelta { get; set; }
}