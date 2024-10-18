using System;
namespace Jawlaty.Models
{
	public abstract class Place
	{
		public Place()
		{
		}

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }


        public virtual ICollection<UserRating> Ratings { get; set; }
        public virtual ICollection<UserFavorite> Favourits { get; set; }

       
    }
}

