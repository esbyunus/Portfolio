﻿using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;
using Portfolio.DL.Entities;

namespace Portfolio.Controllers
{
	public class ContactController : Controller
	{
		private readonly PortfolioContext _context;

		public ContactController(PortfolioContext context)
		{
			_context = context;
		}

		public IActionResult ContactList()
		{
			var values = _context.Contacts.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateContact(Contact Contact)
		{
			_context.Contacts.Add(Contact);
			_context.SaveChanges();
			return RedirectToAction("ContactList");
		}

		public IActionResult DeleteContact(int id)
		{
			var value = _context.Contacts.Find(id);
			_context.Contacts.Remove(value);
			_context.SaveChanges();
			return RedirectToAction("ContactList");
		}

		[HttpGet]
		public IActionResult UpdateContact(int id)
		{
			var value = _context.Contacts.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateContact(Contact Contact)
		{
			_context.Contacts.Update(Contact);
			_context.SaveChanges();
			return RedirectToAction("ContactList");
		}
	}
}
