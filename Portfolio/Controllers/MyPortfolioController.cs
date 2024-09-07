using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;
using Portfolio.DL.Entities;

namespace Portfolio.Controllers
{
	public class MyPortfolioController : Controller
	{
		private readonly PortfolioContext _context;

		public MyPortfolioController(PortfolioContext context)
		{
			_context = context;
		}

		public IActionResult MyPortfolioList()
		{
			var values = _context.MyPortfolios.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateMyPortfolio()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateMyPortfolio(MyPortfolio MyPortfolio)
		{
			_context.MyPortfolios.Add(MyPortfolio);
			_context.SaveChanges();
			return RedirectToAction("MyPortfolioList");
		}

		public IActionResult DeleteMyPortfolio(int id)
		{
			var value = _context.MyPortfolios.Find(id);
			_context.MyPortfolios.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("MyPortfolioList");
		}

		[HttpGet]
		public IActionResult UpdateMyPortfolio(int id)
		{
			var value = _context.MyPortfolios.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateMyPortfolio(MyPortfolio MyPortfolio)
		{
			_context.MyPortfolios.Update(MyPortfolio);
			_context.SaveChanges();
			return RedirectToAction("MyPortfolioList");
		}
	}
}
