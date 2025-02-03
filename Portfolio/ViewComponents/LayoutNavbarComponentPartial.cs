using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;

namespace Portfolio.ViewComponents
{
    public class LayoutNavbarComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public LayoutNavbarComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.UnreadMessageCount = _context.Messages.Count(x => !x.IsRead);
            return View();
        }
    }
} 