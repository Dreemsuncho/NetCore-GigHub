namespace NetCore_GigHub.Entities
{
    public class ClaimUser
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
