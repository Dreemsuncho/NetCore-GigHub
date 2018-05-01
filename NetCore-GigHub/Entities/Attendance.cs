namespace NetCore_GigHub.Entities
{
    public class Attendance
    {
        public Gig Gig { get; set; }
        public int GigId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
