using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;

namespace Portfolio.ViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _AboutComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle=_context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubDescription=_context.Abouts.Select(x=>x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetail = _context.Abouts.Select(x=>x.Details).FirstOrDefault();
            return View();
        }
    }
}
