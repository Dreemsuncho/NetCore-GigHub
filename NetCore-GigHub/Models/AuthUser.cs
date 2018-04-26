using NetCore_GigHub.Entities;
using System.Collections.Generic;

namespace NetCore_GigHub.Models
{
    public class AuthUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }

        public List<ClaimUser> Claims { get; set; }
    }
}
