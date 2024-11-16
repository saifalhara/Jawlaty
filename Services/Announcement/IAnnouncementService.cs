using System.Collections.Generic;
using System.Threading.Tasks;
using Jawlaty.Models;

public interface IAnnouncementService
{
    IEnumerable<Announcement> GetAllAnnouncements();
    Task<Announcement> GetAnnouncementById(int id);
    Task CreateAnnouncement(Announcement announcement);
    Task UpdateAnnouncement(Announcement announcement);
    Task DeleteAnnouncement(int id);
    Task<List<Announcement>> Search(string Trem);
}
