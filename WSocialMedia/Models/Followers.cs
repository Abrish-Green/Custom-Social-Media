using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    [Keyless]

    public class Followers
    {
        public string UserId { get; set; }
        public bool IsFollowedBack { get; set; }
    }
}
