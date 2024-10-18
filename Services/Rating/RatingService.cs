using System;
using Jawlaty.Data;
using Jawlaty.Models;

namespace Jawlaty.Services.Rating
{
    public class RatingService : IRatingService
    {
        private readonly JawlatyDbContext _context;

        public RatingService(JawlatyDbContext context)
        {
            _context = context;
        }

        public void AddRating(UserRating rating)
        {
            _context.UserRatings.Add(rating);
            _context.SaveChanges();
        }
    }
}
