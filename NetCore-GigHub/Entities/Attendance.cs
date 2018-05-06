namespace NetCore_GigHub.Entities
{
    public class Attendance
    {
        public int UserId { get; set; }
        public int GigId { get; set; }

        public User User { get; set; }
        public Gig Gig { get; set; }
    }
}
