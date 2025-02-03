using Portfolio.DL.Entities;
using System.Collections.Generic;

namespace Portfolio.Models
{
    public class SearchViewModel
    {
        public string SearchTerm { get; set; }
        public List<About> Abouts { get; set; } = new List<About>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<MyPortfolio> Portfolios { get; set; } = new List<MyPortfolio>();
        public List<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
        public List<Message> Messages { get; set; } = new List<Message>();
    }
} 