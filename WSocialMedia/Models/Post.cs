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

        public WSocialMediaUser User { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
