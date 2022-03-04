using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WSocialMedia.Areas.Identity.Data;
namespace SocialMedia.Models
{
    public class Like
    {
        [Key]
        public string likeID { get; set; }
        public string PostId { get; set; }

        public string UserId { get; set; }

        public virtual WSocialMediaUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}
