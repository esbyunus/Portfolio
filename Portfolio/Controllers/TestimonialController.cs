using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;
using Portfolio.DL.Entities;

namespace Portfolio.Controllers
{
	public class TestimonialController : Controller
	{
		private readonly PortfolioContext _context;

		public TestimonialController(PortfolioContext context)
		{
			_context = context;
		}

		public IActionResult TestimonialList()
		{
			var values = _context.Testimonials.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateTestimonial()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateTestimonial(Testimonial Testimonial)
		{
			_context.Testimonials.Add(Testimonial);
			_context.SaveChanges();
			return RedirectToAction("TestimonialList");
		}

		public IActionResult DeleteTestimonial(int id)
		{
			var value = _context.Testimonials.Find(id);
			_context.Testimonials.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("TestimonialList");
		}

		[HttpGet]
		public IActionResult UpdateTestimonial(int id)
		{
			var value = _context.Testimonials.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateTestimonial(Testimonial Testimonial)
		{
			_context.Testimonials.Update(Testimonial);
			_context.SaveChanges();
			return RedirectToAction("TestimonialList");
		}
	}
}
