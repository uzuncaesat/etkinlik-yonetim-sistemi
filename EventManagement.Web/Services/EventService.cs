using Microsoft.EntityFrameworkCore;
using EventManagement.Web.Data;
using EventManagement.Web.Models;
using EventManagement.Web.ViewModels;

namespace EventManagement.Web.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<Event>> GetActiveEventsAsync()
        {
            return await _context.Events
                .Include(e => e.Creator)
                .Where(e => e.Status == "active" && e.StartDate > DateTime.UtcNow)
                .OrderBy(e => e.StartDate)
                .ToListAsync();
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events
                .Include(e => e.Creator)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(int id)
        {
            return await _context.Events
                .Include(e => e.Creator)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Event>> GetRecentEventsAsync(int count = 5)
        {
            return await _context.Events
                .Include(e => e.Creator)
                .Where(e => e.Status == "active")
                .OrderByDescending(e => e.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<bool> CreateEventAsync(EventViewModel model, int userId)
        {
            try
            {
                string? imagePath = null;
                if (model.ImageFile != null)
                {
                    imagePath = await SaveImageAsync(model.ImageFile);
                }

                var eventEntity = new Event
                {
                    Title = model.Title,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    ImagePath = imagePath,
                    Status = model.Status,
                    CreatedBy = userId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Events.Add(eventEntity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateEventAsync(EventViewModel model)
        {
            try
            {
                var existingEvent = await _context.Events.FindAsync(model.Id);
                if (existingEvent == null)
                {
                    return false;
                }

                string? imagePath = existingEvent.ImagePath;
                if (model.ImageFile != null)
                {
                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(existingEvent.ImagePath))
                    {
                        DeleteImage(existingEvent.ImagePath);
                    }
                    imagePath = await SaveImageAsync(model.ImageFile);
                }

                existingEvent.Title = model.Title;
                existingEvent.ShortDescription = model.ShortDescription;
                existingEvent.LongDescription = model.LongDescription;
                existingEvent.StartDate = model.StartDate;
                existingEvent.EndDate = model.EndDate;
                existingEvent.ImagePath = imagePath;
                existingEvent.Status = model.Status;
                existingEvent.UpdatedAt = DateTime.UtcNow;

                _context.Events.Update(existingEvent);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            try
            {
                var eventEntity = await _context.Events.FindAsync(id);
                if (eventEntity == null)
                {
                    return false;
                }

                // Delete image if exists
                if (!string.IsNullOrEmpty(eventEntity.ImagePath))
                {
                    DeleteImage(eventEntity.ImagePath);
                }

                _context.Events.Remove(eventEntity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EventExistsAsync(string title, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _context.Events.AnyAsync(e => e.Title == title && e.Id != excludeId.Value);
            }
            return await _context.Events.AnyAsync(e => e.Title == title);
        }

        private async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return "/uploads/" + uniqueFileName;
        }

        private void DeleteImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return;

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
} 