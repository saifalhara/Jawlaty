using System;
using System.Collections.Generic;
using System.Linq;
using Jawlaty.Data;
using Jawlaty.Models;
using Microsoft.EntityFrameworkCore;

public class TransportationService : ITransportationService
{
    private readonly JawlatyDbContext _context;

    public TransportationService(JawlatyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Transportation> GetAllTransportations()
    {
        return _context.Transportations
                       .Include(t => t.City)  // Include City to load city details
                       .ToList();
    }

    public IEnumerable<Transportation> GetTransportationByCityId(int cityId)
    {
        return _context.Transportations.Where(t => t.CityId == cityId).ToList();
    }


    public void AddTransportation(Transportation transportation)
    {
        _context.Transportations.Add(transportation);
        _context.SaveChanges();
    }

    public void UpdateTransportation(Transportation transportation)
    {
        _context.Transportations.Update(transportation);
        _context.SaveChanges();
    }

    public void DeleteTransportation(int id)
    {
        var transportation = _context.Transportations.Find(id);
        if (transportation != null)
        {
            _context.Transportations.Remove(transportation);
            _context.SaveChanges();
        }
    }

    public Transportation GetTransportationById(int id)
    {
        return _context.Transportations
                          .Include(t => t.City) 
                          .FirstOrDefault(t => t.Id == id);
    }

    public async Task<List<Transportation>> Search(string trem)
    {
       return await _context.Transportations.AsNoTracking().Where(x=>x.Title.Contains(trem)).ToListAsync();
    }
}
