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

		public IActionResult Index()
		{
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

		public async Task<IActionResult> GetMacAddress(int Id)
		{
			var result = await _macService.GetAddressDetails(new GetAddressDetails { Id = Id }) ;
			return Json(result);
		}

		public async Task<IActionResult> DeleteMacAddress(int Id)
		{
			var result = new JsonResultModel
			{
				ErrorMessage = string.Empty
			};

			try
			{
				await _macService.DeleteAddress(new DeleteAddress { Id = Id });
				result.IsSuccess = true;
			}
			catch (Exception ex) { throw; }

			
			return Json(result);
		}

		public async Task<IActionResult> SaveMacAddress(MacAddressModel viewModel)
		{
			var result = new JsonResultModel
			{
				ErrorMessage = string.Empty
			};

			try
			{
				await _macService.UpdateAddress(new UpdateAddress
				{
					Id = viewModel.Id,
					Address = viewModel.Address,
					Description = viewModel.Description
				});

				result.IsSuccess = true;
			}
			catch (Exception ex) { throw; }

			return Json(result);
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
