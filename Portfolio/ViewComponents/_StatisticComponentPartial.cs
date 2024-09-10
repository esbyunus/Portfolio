using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.DL.Context;

namespace Portfolio.ViewComponents
{
    public class _StatisticComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _StatisticComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Skills.Count();
            ViewBag.v2 = _context.MyPortfolios.Count();
            ViewBag.v3 = _context.Testimonials.Count();
            ViewBag.v4 = _context.Experiences.Count();
            return View();
        }
    }
}
