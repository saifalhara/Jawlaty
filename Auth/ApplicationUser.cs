using System;
using Jawlaty.Models;
using Microsoft.AspNetCore.Identity;

namespace Jawlaty.Auth
{
	public class ApplicationUser: IdentityUser
    {
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
        public virtual ICollection<UserRating> UserRatings { get; set; }

    }
}

