using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;

namespace Portfolio.ViewComponents
{
    public class _MyPortfolioComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _MyPortfolioComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.MyPortfolios.ToList();
            return View(values);
        }
    }
}
