﻿using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;

namespace Portfolio.ViewComponents
{
    public class _FeatureComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _FeatureComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.socialMedia = _context.SocialMedias.ToList();
            var values = _context.Features.ToList();
            return View(values);
        }
    }
}
