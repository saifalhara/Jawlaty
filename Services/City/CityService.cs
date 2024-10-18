using System.Collections.Generic;
using System.Linq;
using Jawlaty.Data;
using Jawlaty.Models;

public class CityService : ICityService
{
    private readonly JawlatyDbContext _context;

    public CityService(JawlatyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<City> GetAllCities()
    {
        return _context.Cities.ToList();
    }

    public City GetCityById(int id)
    {
        return _context.Cities.FirstOrDefault(c => c.Id == id);
    }

    public void AddCity(City city)
    {
        _context.Cities.Add(city);
        _context.SaveChanges();
    }

    public void UpdateCity(City city)
    {
        _context.Cities.Update(city);
        _context.SaveChanges();
    }

    public void DeleteCity(int id)
    {
        var city = _context.Cities.Find(id);
        if (city != null)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }
    }
}
