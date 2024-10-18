using Jawlaty.Auth.Services;
using Jawlaty.Data;
using Jawlaty.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

public class UserFavoriteService : IUserFavoriteService
{
    private readonly JawlatyDbContext _context;

    public UserFavoriteService(JawlatyDbContext context)
    {
        _context = context;
    }

    public void AddToFavourite(UserFavorite fav)
    {
        _context.UserFavorites.Add(fav);
        _context.SaveChanges();
    }


    // Remove favorite
    public void RemoveFromFavourite(UserFavorite fav)
    {
        _context.UserFavorites.Remove(fav);
        _context.SaveChanges();
    }



    public bool IsFavorite(string userId, int placeId, string placeType)
    {
        return _context.UserFavorites.Any(fav =>
            fav.UserId == userId &&
            ((placeType == "Hotel" && fav.HotelId == placeId) ||
             (placeType == "Restaurant" && fav.RestaurantId == placeId) ||
             (placeType == "Entertainment" && fav.EntertainmentId == placeId))
        );
    }

    public UserFavorite GetFavoriteByUserAndPlace(string userId, int placeId, string placeType)
    {
        return _context.UserFavorites.FirstOrDefault(fav =>
            fav.UserId == userId &&
            ((placeType == "Hotel" && fav.HotelId == placeId) ||
             (placeType == "Restaurant" && fav.RestaurantId == placeId) ||
             (placeType == "Entertainment" && fav.EntertainmentId == placeId))
        );
    }


    public List<UserFavorite> GetUserFavorites(string userId)
    {
        return _context.UserFavorites
                       .Include(f => f.Hotel)
                       .Include(f => f.Restaurant)
                       .Include(f => f.Entertainment)
                       .Include(f => f.Announcement)
                       .Where(f => f.UserId == userId)
                       .ToList();
    }




}
