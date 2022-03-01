using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    [Keyless]
    public class Comment
    {
        public string UserId { get; }
        public string PostId { get; }

        [Required]
        [DefaultValue("")]
        public string CommentContent { get; set; }
    }
}
