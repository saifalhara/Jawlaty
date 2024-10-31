using Jawlaty.Models;

namespace Jawlaty.Services
{
    public interface IVenueService
    {
        Task<IEnumerable<Venue>> GetAllVenue();
        Task AddVenue(Venue Venueobj);

        Task UpdateVenue(Venue venueobj);

        Task DeleteVenue(int VenueID);

       Task<Venue> GetByID(int VenueID);

        Task ApprovedVenue(Venue venue);
    }
}
