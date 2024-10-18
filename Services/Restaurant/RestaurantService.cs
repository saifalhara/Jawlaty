using System;
using Jawlaty.Data;
using Jawlaty.Models;
using Microsoft.EntityFrameworkCore;

public class RestaurantService : IRestaurantService
{
    private readonly JawlatyDbContext _context;

    public RestaurantService(JawlatyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Restaurant> GetAllRestaurants()
    {

        return _context.Restaurants
                     .Include(h => h.Ratings)  // Eager loading
                      .ToList();
    }

    public Restaurant GetRestaurantById(int id)
    {

        return _context.Restaurants
                     .Include(h => h.Ratings)
                     .ThenInclude(r => r.User) // Ensure User is loaded with each Rating
                     .FirstOrDefault(h => h.Id == id);
    }

    public void AddRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Add(restaurant);
        _context.SaveChanges();
    }

    public void UpdateRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Update(restaurant);
        _context.SaveChanges();
    }

    public void DeleteRestaurant(int id)
    {
       

        var restaurant = _context.Restaurants.Find(id);
        if (restaurant != null)
        {
            var userFavorites = _context.UserFavorites.Where(uf => uf.RestaurantId == id);
            _context.UserFavorites.RemoveRange(userFavorites);

            var userRatings = _context.UserRatings.Where(ur => ur.RestaurantId == id);
            _context.UserRatings.RemoveRange(userRatings);

            _context.Restaurants.Remove(restaurant);

            _context.SaveChanges();
        }



    }


    public void ToggleFavorite(int restId, bool isFavorite)
    {
        var hotel = GetRestaurantById(restId);

        if (hotel != null)
        {
            // hotel.IsFavourite = isFavorite;
            _context.SaveChanges();
        }
    }



}
