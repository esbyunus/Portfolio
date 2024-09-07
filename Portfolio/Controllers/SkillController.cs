using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;
using Portfolio.DL.Entities;

namespace Portfolio.Controllers
{
	public class SkillController : Controller
	{
		private readonly PortfolioContext _context;

		public SkillController(PortfolioContext context)
		{
			_context = context;
		}

		public IActionResult SkillList()
		{
			var values = _context.Skills.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateSkill()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateSkill(Skill Skill)
		{
			_context.Skills.Add(Skill);
			_context.SaveChanges();
			return RedirectToAction("SkillList");
		}

		public IActionResult DeleteSkill(int id)
		{
			var value = _context.Skills.Find(id);
			_context.Skills.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("SkillList");
		}

		[HttpGet]
		public IActionResult UpdateSkill(int id)
		{
			var value = _context.Skills.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateSkill(Skill Skill)
		{
			_context.Skills.Update(Skill);
			_context.SaveChanges();
			return RedirectToAction("SkillList");
		}
	}
}
