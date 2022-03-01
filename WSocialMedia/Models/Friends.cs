using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Models
{
    [Keyless]

    public class Friends
    {
        public string UserId { get; set; }
        [DefaultValue(false)]
        public bool IsFriend { get; set; }
    }
}
