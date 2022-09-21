using Mac.Models;
using Mac.Models.StoredProcedure;
using Mac.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mac.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IMacService _macService;

		public HomeController(ILogger<HomeController> logger, IMacService macService)
		{
			_logger = logger;
			_macService = macService;
		}

		public async Task<IActionResult> Index()
		{
			var test = _macService.GetAddresses();
			await _macService.UpdateAddress(new UpdateAddress { Address = "01089054", Description = "Desc 1"});

			return View();
		}

		#region Default

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		#endregion
	}
}
