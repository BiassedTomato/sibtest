using System;
using System.Collections.Generic;

namespace CompanyWebApp.Models.ReportData
{
	public class ShopReport
	{
		public string ShopId { get; set; }
		public string ShopName { get; set; }
		public IEnumerable<RepairReportDTO> Repairs { get; set; }
		public int TotalCount { get; set; }
		public float TotalSum { get; set; }
	}

	public class VehicleReport
	{
		public string VehicleNumber { get; set; }
		public string VehicleModel { get; set; }
		public IEnumerable<RepairReportDTO> Repairs { get; set; }
		public int TotalCount { get; set; }
		public float TotalSum { get; set; }
		public float MileageDelta { get; set; }
	}

	public class ClientReport
	{
		public string ClientId { get; set; }
		public string ClientName { get; set; }
		public IEnumerable<RepairReportDTO> Repairs { get; set; }
		public int TotalCount { get; set; }
		public float TotalSum { get; set; }
	}

	public class RepairsReport
	{
		public IEnumerable<RepairReportDTO> Repairs { get; set; }
		public int TotalCount { get; set; }
		public float TotalSum { get; set; }
	}

	public class RepairReportDTO
	{
		public string ClientName { get; set; }
		public string ClientId { get; set; }
		public string ServiceType { get; set; }
		public string ShopName { get; set; }
		public string ShopId { get; set; }
		public float Cost { get; set; }
		public string VehicleModel { get; set; }
		public string VehicleMileage { get; set; }
		public string VehicleNumber { get; set; }
		public DateTime FinishedDate { get; set; }
	}
}
