using Jawlaty.Models;
using Jawlaty.Models.Trips;

namespace Jawlaty.Services
{
    public interface ITripsService
    {
        Task<IEnumerable<Trips>> GetTrips();

        Task AddTrips(Trips Tripsobj);

        Task UpdateTrips(Trips Tripsobj);

        Task DeleteTrips(int TripsID);

        Task<Trips> GetByID(int TripsID);
    }
}
