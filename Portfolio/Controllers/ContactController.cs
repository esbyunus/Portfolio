using Microsoft.AspNetCore.Mvc;
using Portfolio.DL.Context;
using Portfolio.DL.Entities;
using Portfolio.Services;
using System.Net;
using System.Net.Mail;

namespace Portfolio.Controllers
{
	public class ContactController : Controller
	{
		private readonly PortfolioContext _context;
		private readonly IConfiguration _configuration;

		public ContactController(PortfolioContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
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

		[HttpPost]
		public IActionResult SendMessage(Message message)
		{
			try
			{
				message.SendDate = DateTime.Now;
				message.IsRead = false;
				
				// Email gönderme işlemi
				var emailSettings = _configuration.GetSection("EmailSettings").Get<EmailSettings>();
				using (var client = new SmtpClient(emailSettings.Host))
				{
					client.Port = emailSettings.Port;
					client.Credentials = new NetworkCredential(emailSettings.Email, emailSettings.Password);
					client.EnableSsl = true;

					var mailMessage = new MailMessage
					{
						From = new MailAddress(emailSettings.Email),
						Subject = message.Subject,
						Body = $"Gönderen: {message.NameSurname}\nEmail: {message.Email}\n\nMesaj: {message.MessageDetail}",
						IsBodyHtml = false,
					};
					mailMessage.To.Add(emailSettings.Email);

					client.Send(mailMessage);
				}

				// Mesajı veritabanına kaydet
				_context.Messages.Add(message);
				_context.SaveChanges();

				TempData["MessageSuccess"] = "Mesajınız başarıyla gönderildi.";
				return Redirect("/#home");
			}
			catch (Exception ex)
			{
				TempData["MessageError"] = "Mesaj gönderilirken bir hata oluştu.";
				return Redirect("/#home");
			}
		}
	}
}
