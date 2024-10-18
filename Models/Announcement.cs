using System;
using System.ComponentModel.DataAnnotations;

namespace Jawlaty.Models
{
    public class Announcement
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string LongDescription { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool IsFavorite { get; set; }

        // Navigation property
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
        // each announcment is lined to list of favourits as many users can fav one announcment
    }
}