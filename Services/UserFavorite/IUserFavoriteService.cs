using System.Collections.Generic;
using System.Threading.Tasks;
using Jawlaty.Models;

public interface IUserFavoriteService
{
    public void AddToFavourite(UserFavorite fav);
    public void RemoveFromFavourite(UserFavorite fav);
    public bool IsFavorite(string userId, int placeId, string placeType);
    public List<UserFavorite> GetUserFavorites(string userId);
    public UserFavorite GetFavoriteByUserAndPlace(string userId, int placeId, string placeType);






}
