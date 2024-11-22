using System;
using System.ComponentModel.DataAnnotations;
using Jawlaty.Auth;
using Jawlaty.Models;
namespace Jawlaty.Models;

public class Hotel : Place
{
    public double AverageRating { get; set; }

    // Foreign Key for City
    public int? CityId { get; set; }

    // Navigation property
    public virtual City City { get; set; }

    /// <summary>
    /// Amenities
    /// </summary>
    [Display(Name = "Has Wifi")]
    public bool HASWIFI { get; set; }
    [Display(Name = "Has Pool")]
    public bool HASPOOL { get; set; }
    [Display(Name = "Has Gym")]
    public bool HasGym { get; set; }
    [Display(Name = "Has Spa")]
    public bool HasSpa { get; set; }
    [Display(Name = "Has Restaurant")]
    public bool HasRestaurant { get; set; }
    [Display(Name = "Has Parking")]
    public bool Parking { get; set; }

    /// <summary>
    /// interests 
    /// </summary>
    public bool Food { get; set; }

    public bool Art { get; set; }

    public bool History { get; set; }

    public bool Sports { get; set; }

    public bool Shopping { get; set; }
}

