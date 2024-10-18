using System;
using Jawlaty.Auth;
using Jawlaty.Models;
namespace Jawlaty.Models
{
    public class Hotel : Place
    {
        public double AverageRating { get; set; }

        // Foreign Key for City
        public int? CityId { get; set; }

        // Navigation property
        public virtual City City { get; set; }
    }

}

