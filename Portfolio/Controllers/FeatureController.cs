using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;
using Portfolio.DL.Entities;

namespace Portfolio.Controllers
{

		public class FeatureController : Controller
		{
			private readonly PortfolioContext _context;

			public FeatureController(PortfolioContext context)
			{
				_context = context;
			}

			public IActionResult FeatureList()
			{
				var values = _context.Features.ToList();
				return View(values);
			}

			[HttpGet]
			public IActionResult CreateFeature()
			{
				return View();
			}

			[HttpPost]
			public IActionResult CreateFeature(Feature Feature)
			{
				_context.Features.Add(Feature);
				_context.SaveChanges();
				return RedirectToAction("FeatureList");
			}

			public IActionResult DeleteFeature(int id)
			{
				var value = _context.Features.Find(id);
				_context.Features.Remove(value);
				_context.SaveChanges();
				return RedirectToAction("FeatureList");
			}

			[HttpGet]
			public IActionResult UpdateFeature(int id)
			{
				var value = _context.Features.Find(id);
				return View(value);
			}

			[HttpPost]
			public IActionResult UpdateFeature(Feature Feature)
			{
				_context.Features.Update(Feature);
				_context.SaveChanges();
				return RedirectToAction("FeatureList");
			}
		}
	}

