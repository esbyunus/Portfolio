using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;
using Portfolio.DL.Entities;

namespace Portfolio.Controllers
{
	public class AboutController : Controller
	{
		private readonly PortfolioContext _context;

		public AboutController(PortfolioContext context)
		{
			_context = context;
		}

		public IActionResult AboutList()
		{
			var values = _context.Abouts.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateAbout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateAbout(About about)
		{
			_context.Abouts.Add(about);
			_context.SaveChanges();
			return RedirectToAction("AboutList");
		}

		public IActionResult DeleteAbout(int id)
		{
			var value = _context.Abouts.Find(id);
			_context.Abouts.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("ExperienceList");
		}

		[HttpGet]
		public IActionResult UpdateAbout(int id)
		{
			var value = _context.Abouts.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateAbout(About about)
		{
			_context.Abouts.Update(about);
			_context.SaveChanges();
			return RedirectToAction("AboutList");
		}
	}
}
