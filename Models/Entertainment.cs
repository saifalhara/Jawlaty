using System;
using System.ComponentModel.DataAnnotations;
using Jawlaty.Models;
namespace Jawlaty.Models;

	public class Entertainment : Place
	{
    public double AverageRating { get; set; }

    // Foreign Key for City
    public int? CityId { get; set; }

    // Navigation property
    public virtual City City { get; set; }
    [Display(Name ="Has Live Music")]
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

}
public enum CheakAge
{
    Select=0,AllAges,Above18
}

