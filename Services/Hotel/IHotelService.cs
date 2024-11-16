using System;
using Jawlaty.Models;


public interface IHotelService
{
    IEnumerable<Hotel> GetAllHotels();
    Hotel GetHotelById(int id);
    void AddHotel(Hotel hotel);
    void UpdateHotel(Hotel hotel);
    void DeleteHotel(int id);
    void ToggleFavorite(int hotelId, bool isFavorite);
    Task<List<Hotel>> Search(string trem);

}


