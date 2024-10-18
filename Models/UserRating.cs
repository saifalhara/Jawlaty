using System;
using System.ComponentModel.DataAnnotations.Schema;
using Jawlaty.Auth;

namespace Jawlaty.Models
{
    public class UserRating
    {
        public int Id { get; set; }
        public int RatingValue { get; set; }  // Rating value (e.g., 1-5)
        public string Comment { get; set; }   //  comment from the user

        public string UserId { get; set; }    // Foreign key for the user
        public ApplicationUser User { get; set; }  // Navigation property for the user

        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public int? EntertainmentId { get; set; }
        public Entertainment Entertainment { get; set; }
    }
}