using Microsoft.EntityFrameworkCore;
using Portfolio.DL.Entities;

namespace Portfolio.DL.Context
{
	public class PortfolioContext:DbContext
	{
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Experience> Experiences { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<MyPortfolio> MyPortfolios { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<SocialMedia> SocialMedias { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
	}
}
