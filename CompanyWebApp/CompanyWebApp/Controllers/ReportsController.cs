using CompanyWebApp.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace CompanyWebApp.Controllers
{
	public class ReportsController : Controller
	{
		private readonly HttpClient _httpClient;

		public ReportsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		private async Task<IEnumerable<Report>?> GetReports()
		{
			var reports = await _httpClient.GetAsync("https://localhost:5001/company/client");

			if (reports.IsSuccessStatusCode)
			{
				return await reports.Content.ReadFromJsonAsync<IEnumerable<Report>>();
			}

			return null;
		}

		public async Task<IActionResult> Index()
		{
			var reports = await GetReports();
			return View("ReportsView", reports);
		}
	}
}

