using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Web.Models;
using EventManagement.Web.Services;
using EventManagement.Web.ViewModels;

namespace EventManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;

        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetActiveEventsAsync();
            return View(events);
        }

        public async Task<IActionResult> EventDetail(int id)
        {
            var eventDetail = await _eventService.GetEventByIdAsync(id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            var recentEvents = await _eventService.GetRecentEventsAsync();
            ViewBag.RecentEvents = recentEvents;

            return View(eventDetail);
        }

        public async Task<IActionResult> Calendar()
        {
            var events = await _eventService.GetActiveEventsAsync();
            return View(events);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
