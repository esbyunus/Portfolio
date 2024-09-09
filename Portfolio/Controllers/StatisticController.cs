using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;

namespace Portfolio.Controllers
{
	public class StatisticController : Controller
	{
		private readonly PortfolioContext _context;

		public StatisticController(PortfolioContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			ViewBag.v1 = _context.Skills.Count();
			ViewBag.v2 = _context.Messages.Count();
			ViewBag.v3 = _context.Messages.Where(x => x.IsRead == false).Count();
			ViewBag.v4 = _context.Messages.Where(x => x.IsRead == true).Count();
			return View();
		}
	}
}
