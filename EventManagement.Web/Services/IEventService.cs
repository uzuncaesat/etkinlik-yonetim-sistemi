using EventManagement.Web.Models;
using EventManagement.Web.ViewModels;

namespace EventManagement.Web.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetActiveEventsAsync();
        Task<List<Event>> GetAllEventsAsync();
        Task<Event?> GetEventByIdAsync(int id);
        Task<List<Event>> GetRecentEventsAsync(int count = 5);
        Task<bool> CreateEventAsync(EventViewModel model, int userId);
        Task<bool> UpdateEventAsync(EventViewModel model);
        Task<bool> DeleteEventAsync(int id);
        Task<bool> EventExistsAsync(string title, int? excludeId = null);
    }
} 