using System.ComponentModel.DataAnnotations;

namespace Jawlaty.Models;

public class Restaurant : Place
	{
    public double AverageRating { get; set; }

    // Foreign Key for City
    public int? CityId { get; set; }

    // Navigation property
    public virtual City City { get; set; }

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

}