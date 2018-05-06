namespace NetCore_GigHub.Entities
{
    public class Following
    {
        public int FollowerId { get; set; }
        public int FolloweeId { get; set; }

        public User Follower { get; set; }
        public User Followee { get; set; }
    }
}
