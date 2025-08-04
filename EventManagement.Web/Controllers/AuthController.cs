using Microsoft.AspNetCore.Mvc;
using EventManagement.Web.Services;
using EventManagement.Web.ViewModels;

namespace EventManagement.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _authService.LoginAsync(model);
            if (user == null)
            {
                ModelState.AddModelError("", "E-posta adresi veya şifre hatalı.");
                return View(model);
            }

            // Set session
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _authService.RegisterAsync(model);
            if (!success)
            {
                ModelState.AddModelError("", "Bu e-posta adresi zaten kullanılıyor.");
                return View(model);
            }

            TempData["SuccessMessage"] = "Kayıt başarıyla oluşturuldu. Giriş yapabilirsiniz.";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
} 