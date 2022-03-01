using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    [Keyless]

    public class Like
    {
        [Key]
        public string Id { get; set; }
        public string UsersId { get; }
        public int PostId { get; }

    }
}
