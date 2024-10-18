using Jawlaty.Models;
using System.Collections.Generic;

public interface ICityService
{
    IEnumerable<City> GetAllCities();
    City GetCityById(int id);
    void AddCity(City city);
    void UpdateCity(City city);
    void DeleteCity(int id);
}
