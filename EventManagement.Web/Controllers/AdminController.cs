using Microsoft.AspNetCore.Mvc;
using EventManagement.Web.Services;
using EventManagement.Web.ViewModels;
using EventManagement.Web.Models;

namespace EventManagement.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IAuthService _authService;

        public AdminController(IEventService eventService, IAuthService authService)
        {
            _eventService = eventService;
            _authService = authService;
        }

        private bool IsAuthenticated()
        {
            return HttpContext.Session.GetInt32("UserId").HasValue;
        }

        private int GetCurrentUserId()
        {
            return HttpContext.Session.GetInt32("UserId") ?? 0;
        }

        public IActionResult Index()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            var userId = GetCurrentUserId();
            var user = await _authService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(User model)
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _authService.UpdateUserAsync(model);
            if (success)
            {
                TempData["SuccessMessage"] = "Profil başarıyla güncellendi.";
                HttpContext.Session.SetString("UserName", model.Name);
            }
            else
            {
                ModelState.AddModelError("", "Profil güncellenirken bir hata oluştu.");
            }

            return View(model);
        }

        public async Task<IActionResult> Events()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            var events = await _eventService.GetAllEventsAsync();
            return View(events);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(new EventViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventViewModel model)
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if event with same title exists
            if (await _eventService.EventExistsAsync(model.Title))
            {
                ModelState.AddModelError("Title", "Bu başlıkta bir etkinlik zaten mevcut.");
                return View(model);
            }

            var userId = GetCurrentUserId();
            var success = await _eventService.CreateEventAsync(model, userId);
            if (success)
            {
                TempData["SuccessMessage"] = "Etkinlik başarıyla oluşturuldu.";
                return RedirectToAction("Events");
            }

            ModelState.AddModelError("", "Etkinlik oluşturulurken bir hata oluştu.");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditEvent(int id)
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            var eventEntity = await _eventService.GetEventByIdAsync(id);
            if (eventEntity == null)
            {
                return NotFound();
            }

            var model = new EventViewModel
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                ShortDescription = eventEntity.ShortDescription,
                LongDescription = eventEntity.LongDescription,
                StartDate = eventEntity.StartDate,
                EndDate = eventEntity.EndDate,
                ImagePath = eventEntity.ImagePath,
                IsActive = eventEntity.Status == "active"
            };

            return View("CreateEvent", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EventViewModel model)
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            if (!ModelState.IsValid)
            {
                return View("CreateEvent", model);
            }

            // Check if event with same title exists (excluding current event)
            if (await _eventService.EventExistsAsync(model.Title, model.Id))
            {
                ModelState.AddModelError("Title", "Bu başlıkta bir etkinlik zaten mevcut.");
                return View("CreateEvent", model);
            }

            var success = await _eventService.UpdateEventAsync(model);
            if (success)
            {
                TempData["SuccessMessage"] = "Etkinlik başarıyla güncellendi.";
                return RedirectToAction("Events");
            }

            ModelState.AddModelError("", "Etkinlik güncellenirken bir hata oluştu.");
            return View("CreateEvent", model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (!IsAuthenticated())
            {
                return RedirectToAction("Login", "Auth");
            }

            var success = await _eventService.DeleteEventAsync(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Etkinlik başarıyla silindi.";
            }
            else
            {
                TempData["ErrorMessage"] = "Etkinlik silinirken bir hata oluştu.";
            }

            return RedirectToAction("Events");
        }
    }
} 