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
	public class ShopController : Controller
	{
		private readonly HttpClient _httpClient;

		public ShopController(HttpClient httpClient)
		{
			_httpClient = httpClient;
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

		public async Task<IActionResult> Index()
		{
			return View();
		}

		[Route("report")]
		public async Task<IActionResult> ShopReport([FromQuery] string shopNumber, string startDate, string endDate)
		{
			return View("ShopSideReportView", await GetShopReport(shopNumber, startDate, endDate));
		}
	}
}

