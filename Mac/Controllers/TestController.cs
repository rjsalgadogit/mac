using Mac.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mac.Controllers
{
	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
