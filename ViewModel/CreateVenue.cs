using Jawlaty.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jawlaty.ViewModel
{
    public class CreateVenue
    {
        [StringLength(100)]
        [Required]
        [Display(Name = "Arabic Name")]
        public string ArName { get; set; }=string.Empty;

        [StringLength(100)]
        [Required]
        [Display(Name = "English Name")]
        public string EnName { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = string.Empty;

        [StringLength(500)]
        [Required]
        public string Description { get; set; } = string.Empty;

        public IEnumerable<SelectListItem> Citys { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "City")]
        public int CityID { get; set; } = new();

        public bool? Succsed { get; set; }

        [Required]
        [Range(1, 4)]
        [Display(Name = "Venue Type")]
        public VenueType VenueType { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
