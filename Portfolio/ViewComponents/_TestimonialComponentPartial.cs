using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;

namespace Portfolio.ViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _TestimonialComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }
    }
}
