using System;
using Jawlaty.Data;
using Jawlaty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HotelService : IHotelService
{
    private readonly JawlatyDbContext _context;

    public HotelService(JawlatyDbContext context)
    {
        _context = context;
    }

  

    public IEnumerable<Hotel> GetAllHotels()
    {
        return _context.Hotels
                       .Include(h => h.Ratings)  // Eager loading
                        .ToList();
    }



    public Hotel GetHotelById(int id)
    {
        return _context.Hotels
                       .Include(h => h.Ratings)
                       .ThenInclude(r => r.User) // Ensure User is loaded with each Rating
                       .FirstOrDefault(h => h.Id == id);
    }



    public void AddHotel(Hotel hotel)
    {
        _context.Hotels.Add(hotel);
        _context.SaveChanges();
    }

    public void UpdateHotel(Hotel hotel)
    {
        _context.Hotels.Update(hotel);
        _context.SaveChanges();
    }

    public void DeleteHotel(int id)
    {
        var hotel = _context.Hotels.Find(id);
        if (hotel != null)
        {
            // Find and remove all UserFavorite entries related to this hotel
            var userFavorites = _context.UserFavorites.Where(uf => uf.HotelId == id);
            _context.UserFavorites.RemoveRange(userFavorites);

            // Find and remove all UserRating entries related to this hotel
            var userRatings = _context.UserRatings.Where(ur => ur.HotelId == id);
            _context.UserRatings.RemoveRange(userRatings);

            // Now remove the hotel
            _context.Hotels.Remove(hotel);

            // Save changes to the database
            _context.SaveChanges();
        }
    }




    public void ToggleFavorite(int hotelId, bool isFavorite)
    {
        var hotel = GetHotelById(hotelId);

        if (hotel != null)
        {
           // hotel.IsFavourite = isFavorite;
            _context.SaveChanges();
        }
    }

    public async Task<List<Hotel>> Search(string trem)
    {
        return await _context.Hotels.AsNoTracking().Where(x => x.Title.Contains(trem)).ToListAsync();
    }
}