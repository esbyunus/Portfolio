using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;

namespace Portfolio.ViewComponents
{
    public class _SkillComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _SkillComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values= _context.Skills.ToList();
            return View(values);
        }
    }
}
