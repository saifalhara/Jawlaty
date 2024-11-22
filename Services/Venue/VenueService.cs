using Jawlaty.Data;
using Jawlaty.Models;
using Microsoft.EntityFrameworkCore;

namespace Jawlaty.Services
{
    public class VenueService : IVenueService
    {
        private readonly JawlatyDbContext _context;
        private readonly IHotelService _hotelService;
        private readonly IEntertainmentService _entertainmentService;
        private readonly IRestaurantService _restaurantService;
        private readonly ITransportationService _transportationService;
        public VenueService(JawlatyDbContext context, IHotelService hotelService, IEntertainmentService entertainmentService, IRestaurantService restaurantService, ITransportationService transportationService)
        {
            _context = context;
            _hotelService = hotelService;
            _entertainmentService = entertainmentService;
            _restaurantService = restaurantService;
            _transportationService = transportationService;
        }

        public async Task AddVenue(Venue Venueobj)
        {
            await _context.Venue.AddAsync(Venueobj);
            await _context.SaveChangesAsync();
        }

        public async Task ApprovedVenue(Venue venue)
        {
            switch (venue.VenueType)
            {
                case VenueType.Hotel:
                    Hotel hotel = new() { ImageUrl = venue.ImageUrl, CityId = venue.CityID, Title = venue.Title, Description = venue.Description,HASWIFI=venue.HASWIFI,HASPOOL=venue.HASPOOL,HasGym=venue.HasGym,HasSpa=venue.HasSpa,HasRestaurant=venue.HasRestaurant,Art=venue.Art };
                    _hotelService.AddHotel(hotel);
                    break;

                case VenueType.Entertainment:
                    Entertainment Entertainment = new() { ImageUrl = venue.ImageUrl, CityId = venue.CityID, Title = venue.Title, Description = venue.Description,HasCinema=venue.HasCinema,HasTheater=venue.HasTheater,HasShopping=venue.HasShopping,HasLiveMusic=venue.HasLiveMusic,HasSport=venue.HasSport,CheakAge=venue.CheakAge, };
                    _entertainmentService.AddEntertainment(Entertainment);
                    break;

                case VenueType.ResTaurant:
                    Restaurant restaurant = new() { ImageUrl = venue.ImageUrl, CityId = venue.CityID, Title = venue.Title, Description = venue.Description,Indian=venue.Indian,Italian=venue.Italian,Mexican=venue.Mexican,Glutenfree=venue.Glutenfree,MiAmeicanddle=venue.MiAmeicanddle,TimeInput=venue.TimeInput,Timeout=venue.Timeout,Middle=venue.Middle,Chinese=venue.Chinese,Vegetarian=venue.Vegetarian,Vagen=venue.Vagen, };
                    _restaurantService.AddRestaurant(restaurant);
                    break;

                case VenueType.Transportation:
                    Transportation transportation = new() { CityId = venue.CityID, Title = venue.Title, Content = venue.Description };
                    _transportationService.AddTransportation(transportation);
                    break;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVenue(int VenueID)
        {
            Venue? venueobj = await _context.Venue.AsNoTracking().SingleOrDefaultAsync(x => x.ID == VenueID);
            if (venueobj is not null)
            {
                _context.Venue.Remove(venueobj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Venue>> GetAllVenue()
        {
            return await _context.Venue.AsNoTracking().ToListAsync();
        }

        public async Task<Venue> GetByID(int VenueID)
        {
            Venue? venueobj = await _context.Venue.AsNoTracking().SingleOrDefaultAsync(x => x.ID == VenueID);
            if (venueobj is not null)
            {
                return venueobj;
            }
            return null ?? new Venue();
        }

        public async Task UpdateVenue(Venue venueobj)
        {
            Venue? venueUpdateObj = await _context.Venue.AsNoTracking().SingleOrDefaultAsync(x => x.ID == venueobj.ID);
            if (venueUpdateObj is not null)
            {
                _context.Venue.Update(venueobj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
