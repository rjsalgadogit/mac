using Mac.Models;
using Mac.Models.StoredProcedure;
using Mac.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
			//var test = _macService.GetAddresses();
			await _macService.UpdateAddress(new UpdateAddress { Address = "11089024", Description = "Description" });
			//await _macService.DeleteAddress(new DeleteAddress { Id = 2 });

			return View();
		}

		public async Task<IActionResult> _GridTable(GridModel model)
		{
			return PartialView(await Task.FromResult(model));
		}

		public async Task<string> GetMacAddresses(GetModel parameters)
		{
			var result = new JsonResultModel
			{
				ErrorMessage = string.Empty
			};

			try
			{
				result.Collection = await _macService.GetAddresses(parameters);
			}
			catch (Exception ex) 
			{
				result.ErrorMessage = ex.Message;
			}

			return JsonConvert.SerializeObject(result);
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
