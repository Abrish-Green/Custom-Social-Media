using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Comment
    {
        [Key]
        public string commentID { get; set; }
       
        [Required]
        [DefaultValue("")]
        public string CommentContent { get; set; }
        public string UserId { get; }
        public Post Post { get; set; }
    }
}
