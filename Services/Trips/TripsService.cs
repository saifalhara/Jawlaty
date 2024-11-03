using Jawlaty.Data;
using Jawlaty.Models;
using Jawlaty.Models.Trips;
using Microsoft.EntityFrameworkCore;

namespace Jawlaty.Services
{
    public class TripsService : ITripsService
    {
        private readonly JawlatyDbContext _dbcontext;

        public TripsService(JawlatyDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddTrips(Trips Tripsobj)
        {

            await _dbcontext.Trips.AddAsync(Tripsobj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteTrips(int TripsID)
        {
            Trips? Tripsbj = await _dbcontext.Trips.AsNoTracking().SingleOrDefaultAsync(x => x.ID == TripsID);
            if (Tripsbj is not null)
            {
                _dbcontext.Trips.Remove(Tripsbj);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<Trips> GetByID(int TripsID)
        {
            Trips? Tripsobj = await _dbcontext.Trips.AsNoTracking().SingleOrDefaultAsync(x => x.ID == TripsID);
            if (Tripsobj is not null)
            {
                return Tripsobj;
            }
            return null ?? new Trips();
        }

        public async Task<IEnumerable<Trips>> GetTrips()
        {
            return await _dbcontext.Trips.AsNoTracking().ToListAsync();
        }

        public async Task UpdateTrips(Trips Tripsobj)
        {
            Trips? TripsUpdateObj = await _dbcontext.Trips.AsNoTracking().SingleOrDefaultAsync(x => x.ID == Tripsobj.ID);
            if (TripsUpdateObj is not null)
            {
                _dbcontext.Trips.Update(Tripsobj);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
