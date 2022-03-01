using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }

        [Required] 
        public string PostTitle { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public Post Posts { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Hide { get; set; }

        [Required]
        public string Catagory { get; set; }

        public string UserId { get; }
    }
}
