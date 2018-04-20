using System;
using System.ComponentModel.DataAnnotations;

namespace NetCore_GigHub.Entities
{
    public class Gig
    {
        public int Id { get; set; }

        [Required]
        public int ArtistId { get; set; }
        public User Artist { get; set; }

        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [StringLength(40)]
        public string Venue { get; set; }
        public DateTime DateTime { get; set; }
    }
}
