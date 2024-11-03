using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jawlaty.Models.Trips
{
    public class Trips
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Range(1,7)]
        public byte NumberOfDay { get; set; }

        [Required]
        [Range(1,4)]
        public Withtraveling Withtraveling { get; set; }

        [Required]
        [Range(1,6)]
        public Interest Interest { get; set; }

        public bool? HasChlidren { get; set; }

        [NotMapped]
        public string QuestionOne { get; set; }=string.Empty;

        [NotMapped]
        public string QuestionTwo { get; set; }=string.Empty;

        [NotMapped]
        public string QuestionThree { get; set; } = string.Empty;

        [NotMapped]
        public string QuestionFour { get; set; } = string.Empty;
    }
    public enum Withtraveling:int
    {
        Select=0,Alone,Partner,Family,Friends
    }

    public enum Interest:int
    {
        Select=0,Art,Food,History,Sport,Shoping,Music
    }
}
