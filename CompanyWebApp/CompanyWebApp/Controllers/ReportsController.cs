using CompanyWebApp.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using CompanyWebApp.Models.ReportData;
using System.Web;

namespace CompanyWebApp.Controllers
{
	[Route("[controller]")]
	public class ReportsController : Controller
	{
		private readonly HttpClient _httpClient;

		public ReportsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		private async Task<VehicleReport?> GetVehicleReport(string vehicleNumber, string startDate, string endDate)
		{
			var builder = new UriBuilder("https://localhost:5001/company/vehicle");
			var query = HttpUtility.ParseQueryString(builder.Query);

			query["idNumber"] = vehicleNumber;
			query["startDate"] = startDate;
			query["endDate"] = endDate;

			builder.Query = query.ToString();

			var reports = await _httpClient.GetAsync(builder.ToString());

			if (reports.IsSuccessStatusCode)
			{
				return await reports.Content.ReadFromJsonAsync<VehicleReport>();
			}

			return null;
		}

		private async Task<ShopReport?> GetShopReport(string shopNumber, string startDate, string endDate)
		{
			var builder = new UriBuilder("https://localhost:5001/company/shop");
			var query = HttpUtility.ParseQueryString(builder.Query);

			query["idNumber"] = shopNumber;
			query["startDate"] = startDate;
			query["endDate"] = endDate;

			builder.Query = query.ToString();

			var reports = await _httpClient.GetAsync(builder.ToString());

			if (reports.IsSuccessStatusCode)
			{
				return await reports.Content.ReadFromJsonAsync<ShopReport>();
			}

			return null;
		}

		private async Task<ClientReport?> GetClientReport(string clientNumber, string startDate, string endDate)
		{
			var builder = new UriBuilder("https://localhost:5001/company/client");
			var query = HttpUtility.ParseQueryString(builder.Query);

			query["idNumber"] = clientNumber;
			query["startDate"] = startDate;
			query["endDate"] = endDate;

			builder.Query = query.ToString();

			var reports = await _httpClient.GetAsync(builder.ToString());

			if (reports.IsSuccessStatusCode)
			{
				return await reports.Content.ReadFromJsonAsync<ClientReport>();
			}

			return null;
		}

		private async Task<RepairsReport?> GetRepairsReport(string startDate, string endDate)
		{
			var builder = new UriBuilder("https://localhost:5001/company/repairs");
			var query = HttpUtility.ParseQueryString(builder.Query);

			query["startDate"] = startDate;
			query["endDate"] = endDate;

			builder.Query = query.ToString();

			var reports = await _httpClient.GetAsync(builder.ToString());

			if (reports.IsSuccessStatusCode)
			{
				return await reports.Content.ReadFromJsonAsync<RepairsReport>();
			}

			return null;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}

		[Route("shop")]
		public async Task<IActionResult> ShopReport([FromQuery]string shopNumber, string startDate, string endDate)
		{
			return View("ShopReportView", await GetShopReport(shopNumber, startDate, endDate));
		}

		[Route("client")]
		public async Task<IActionResult> ClientReport([FromQuery] string clientNumber, string startDate, string endDate)
		{
			return View("ClientReportView", await GetClientReport(clientNumber, startDate, endDate));
		}

		[Route("repairs")]
		public async Task<IActionResult> RepairsReport([FromQuery] string startDate, string endDate)
		{
			return View("RepairsReportView", await GetRepairsReport(startDate, endDate));
		}

		[Route("vehicle")]
		public async Task<IActionResult> VehicleReport([FromQuery] string vehicleNumber, string startDate, string endDate)
		{
			return View("VehicleReportView", await GetVehicleReport(vehicleNumber, startDate, endDate));
		}
	}
}

