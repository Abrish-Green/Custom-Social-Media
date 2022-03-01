using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Models
{
    [Keyless]

    public class Following
    {
        public string UserId { get; set; }
        public bool isFollower { get; set; }
    }
}
