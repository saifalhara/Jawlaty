using System;
using Jawlaty.Auth;

namespace Jawlaty.Models
{
	public class UserFavorite
	{
     
        public int Id { get; set; }

        public string UserId { get; set; }    // Foreign key for the user
        public ApplicationUser User { get; set; }  // Navigation property for the user

        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public int? EntertainmentId { get; set; }
        public Entertainment Entertainment { get; set; }

        public int? AnnouncementId { get; set; }    
        public Announcement Announcement { get; set; }  
            
    }
}

