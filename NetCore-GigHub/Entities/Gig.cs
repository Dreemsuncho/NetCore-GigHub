using System;

namespace NetCore_GigHub.Entities
{
    public class Gig
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public User Artist { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Venue { get; set; }
        public DateTime DateTime { get; set; }
    }
}
