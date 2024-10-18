using System;
using Jawlaty.Models;

public interface IRestaurantService
	{
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurantById(int id);
        void AddRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int id);
        void ToggleFavorite(int restId, bool isFavorite);


}


