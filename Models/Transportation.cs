using System;
namespace Jawlaty.Models
{
	public class Transportation
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }  // Article content

        // Foreign key to City
        public int CityId { get; set; }
        public City City { get; set; }
    }
}

