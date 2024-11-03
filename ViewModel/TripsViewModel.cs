using Jawlaty.Models.Trips;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jawlaty.ViewModel
{
    public class TripsViewModel
    {
        [Required]
        [Range(1, 7)]
        public byte NumberOfDay { get; set; }

        [Required]
        [Range(1, 4)]
        public Withtraveling Withtraveling { get; set; }

        [Required]
        [Range(1, 6)]
        public Interest Interest { get; set; }

        public IEnumerable<SelectListItem> WithtravelingOptions { get; set; }

        public bool? HasChlidren { get; set; }

        public string QuestionOne { get; set; } = string.Empty;

        public string QuestionTwo { get; set; } = string.Empty;

        public string QuestionThree { get; set; } = string.Empty;

        public string QuestionFour { get; set; } = string.Empty;
    }
}
