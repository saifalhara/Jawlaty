using System;
namespace Jawlaty.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }




        // Navigation property for the one-to-one relationship
        public virtual ICollection<Transportation> Transportation { get; set; }

        public virtual ICollection<Restaurant> Restaurant { get; set; }
        public virtual ICollection<Hotel> Hotel { get; set; }
        public virtual ICollection<Entertainment> Entertainment { get; set; }
        public ICollection<Venue> LstVenue { get; set; }

    }

}

