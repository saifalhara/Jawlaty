using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jawlaty.Models;

public class Venue
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [StringLength(100)]
    [Required]
    public string ArName { get; set; }

    [StringLength(100)]
    [Required]
    public string EnName { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    [StringLength(500)]
    [Required]
    public string Description { get; set; }

    [Required]
    [ForeignKey(nameof(City))]
    [Range(1, int.MaxValue)]
    public int CityID { get; set; }

    public bool? Succsed { get; set; }

    [Required]
    [Range(1,int.MaxValue)]
    public VenueType VenueType { get; set; }

    [Required]
    public string Title { get; set; }

    #region Hotel
    /// <summary>
    /// Hotel
    /// </summary>
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
    #endregion

    #region Restaurant
    public bool Italian { get; set; }

    public bool Chinese { get; set; }

    public bool Indian { get; set; }

    public bool Middle { get; set; }

    public bool MiAmeicanddle { get; set; }

    public bool Mexican { get; set; }

    public bool Vegetarian { get; set; }

    public bool Vagen { get; set; }
    [Display(Name = "Gluten Free")]
    public bool Glutenfree { get; set; }
    [Display(Name = "Time Input")]
    public DateTime TimeInput { get; set; }
    [Display(Name = "Time Out")]
    public DateTime Timeout { get; set; }
    #endregion

    #region Entertainment
    [Display(Name = "Has Live Music")]
    public bool HasLiveMusic { get; set; }
    [Display(Name = "Has Theater")]
    public bool HasTheater { get; set; }
    [Display(Name = "Has Sport")]
    public bool HasSport { get; set; }
    [Display(Name = "Has Cinema")]
    public bool HasCinema { get; set; }
    [Display(Name = "Has Shopping")]
    public bool HasShopping { get; set; }
    public bool Spa { get; set; }
    [Display(Name = "Cheak Age")]
    public CheakAge CheakAge { get; set; }
    #endregion

    #region NotMapped
    [NotMapped]
    public string CityName { get; set; }
    #endregion
}

public enum VenueType :int
{
    Select=0,Hotel,ResTaurant, Entertainment, Transportation
}
