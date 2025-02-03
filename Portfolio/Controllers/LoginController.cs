using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Portfolio.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Eğer zaten giriş yapmışsa About sayfasına yönlendir
            if (HttpContext.Session.GetString("AdminUser") != null)
            {
                return RedirectToAction("AboutList", "About");
            }

            // Tarayıcı önbelleğini engelle
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            // Hardcoded admin bilgileri (gerçek projede bu bilgiler veritabanında olmalı)
            if (username == "admin" && password == "123456")
            {
                HttpContext.Session.SetString("AdminUser", username);
                return RedirectToAction("AboutList", "About");
            }
            
            ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }

        public IActionResult Logout()
        {
            // Session'ı temizle
            HttpContext.Session.Clear();
            
            // Tarayıcı önbelleğini engelle
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            
            // Ana sayfaya yönlendir
            return RedirectToAction("Index", "Default");
        }
    }
} 