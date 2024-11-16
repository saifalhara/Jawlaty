using System;
using Jawlaty.Data;
using Jawlaty.Models;
using Microsoft.EntityFrameworkCore;

public class EntertainmentService : IEntertainmentService
    {
        private readonly JawlatyDbContext _context;

        public EntertainmentService(JawlatyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Entertainment> GetAllEntertainments()
        {
           
                  return _context.Entertainments
                .Include(h => h.Ratings)  // Eager loading
                 .ToList();
    }

        public Entertainment GetEntertainmentById(int id)
        {

                  return _context.Entertainments
                   .Include(h => h.Ratings)
                   .ThenInclude(r => r.User) // Ensure User is loaded with each Rating
                   .FirstOrDefault(h => h.Id == id);
    }

        public void AddEntertainment(Entertainment entertainment)
        {
            _context.Entertainments.Add(entertainment);
            _context.SaveChanges();
        }

        public void UpdateEntertainment(Entertainment entertainment)
        {
            _context.Entertainments.Update(entertainment);
            _context.SaveChanges();
        }

        public void DeleteEntertainment(int id)
        {
            var entertainment = _context.Entertainments.Find(id);
            if (entertainment != null)
            {
                _context.Entertainments.Remove(entertainment);
                _context.SaveChanges();
            }
        }

    public async Task<List<Entertainment>> Search(string trem)
    {
        return await _context.Entertainments.AsNoTracking().Where(x => x.Title.Contains(trem)).ToListAsync();
    }
}