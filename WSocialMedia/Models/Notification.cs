using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace SocialMedia.Models
{
    [Keyless]

    public class Notification
    {
        public string UserId { get; set; }
        [DefaultValue(0)]
        public int FollowerNotification { get; set; }
        [DefaultValue(0)]
        public int MessageNotification { get; set; }
        [DefaultValue(0)]
        public int NewsFeedNotification { get; set; }
        [DefaultValue(0)]
        public int FriendRequestNotification { get; set; }
    }
}
