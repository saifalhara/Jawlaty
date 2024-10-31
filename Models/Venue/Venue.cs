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

    [NotMapped]
    public string CityName { get; set; }
}

public enum VenueType :int
{
    Select=0,Hotel,ResTaurant, Entertainment, Transportation
}
