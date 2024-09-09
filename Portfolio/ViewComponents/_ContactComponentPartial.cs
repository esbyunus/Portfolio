using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;
using Portfolio.Controllers;

namespace Portfolio.ViewComponents
{
    public class _ContactComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _ContactComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.contactTitle=_context.Contacts.Select(x=> x.Title).FirstOrDefault();
            ViewBag.contactDescription=_context.Contacts.Select(x=> x.Description).FirstOrDefault();
            ViewBag.contactPhone1=_context.Contacts.Select(x=> x.Phone1).FirstOrDefault();
            ViewBag.contactPhone2=_context.Contacts.Select(x=> x.Phone2).FirstOrDefault();
            ViewBag.contactEmail1=_context.Contacts.Select(x=> x.Email1).FirstOrDefault();
            ViewBag.contactEmail2=_context.Contacts.Select(x=> x.Email2).FirstOrDefault();
            ViewBag.contactAddress=_context.Contacts.Select(x=> x.Address).FirstOrDefault();

            
            return View(); 
        }
    }
}
