using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WSocialMedia.Areas.Identity.Data;
namespace SocialMedia.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Hide { get; set; }

        public string UserId { get; set; }
        public virtual WSocialMediaUser User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
       
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
