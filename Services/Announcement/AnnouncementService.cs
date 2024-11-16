using Jawlaty.Data;
using Jawlaty.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AnnouncementService : IAnnouncementService
{
    private readonly JawlatyDbContext _context;

    public AnnouncementService(JawlatyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Announcement> GetAllAnnouncements()
    {
        var products = _context.Announcements;

        return products;

    }

    public async Task<Announcement> GetAnnouncementById(int id)
    {
        return await _context.Announcements.FindAsync(id);
    }



    public async Task CreateAnnouncement(Announcement announcement)
    {
        _context.Announcements.Add(announcement);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAnnouncement(Announcement announcement)
    {
        _context.Announcements.Update(announcement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAnnouncement(int id)
    {
        var announcement = await _context.Announcements.FindAsync(id);
        if (announcement != null)
        {
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Announcement>> Search(string Trem)
    {
        return await _context.Announcements.AsNoTracking().Where(x=>x.Title.Contains(Trem)).ToListAsync();
    }
}
