using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;
using Portfolio.Filters;
using Portfolio.Models;
using System.Linq;

namespace Portfolio.Controllers
{
    [AdminAuthFilter]
    public class SearchController : Controller
    {
        private readonly PortfolioContext _context;

        public SearchController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return View(new SearchViewModel());

            var viewModel = new SearchViewModel
            {
                SearchTerm = searchTerm,
                Abouts = _context.Abouts.Where(x => 
                    x.Title.Contains(searchTerm) || 
                    x.SubDescription.Contains(searchTerm)).ToList(),
                    
                Experiences = _context.Experiences.Where(x => 
                    x.Title.Contains(searchTerm) || 
                    x.Description.Contains(searchTerm)).ToList(),
                    
                Skills = _context.Skills.Where(x => 
                    x.Title.Contains(searchTerm)).ToList(),
                    
                Portfolios = _context.MyPortfolios.Where(x => 
                    x.Title.Contains(searchTerm) || 
                    x.Description.Contains(searchTerm)).ToList(),
                    
                Testimonials = _context.Testimonials.Where(x => 
                    x.NameSurname.Contains(searchTerm) || 
                    x.Description.Contains(searchTerm)).ToList(),
                    
                Messages = _context.Messages.Where(x => 
                    x.NameSurname.Contains(searchTerm) || 
                    x.Subject.Contains(searchTerm) || 
                    x.MessageDetail.Contains(searchTerm)).ToList()
            };

            return View(viewModel);
        }
    }
} 