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
	public class ClientController : Controller
	{
		private readonly HttpClient _httpClient;

		public ClientController(HttpClient httpClient)
		{
			_httpClient = httpClient;
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

		public async Task<IActionResult> Index()
		{
			return View();
		}

		[Route("report")]
		public async Task<IActionResult> ClientReport([FromQuery] string clientNumber, string startDate, string endDate)
		{
			return View("ClientSideReportView", await GetClientReport(clientNumber, startDate, endDate));
		}
	}
}

