using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WSocialMedia.Areas.Identity.Data;
namespace SocialMedia.Models
{
    public class Comment
    {
        [Key]
        public string commentID { get; set; }
       
        [DataType(DataType.DateTime)]
        public DateTime CommentDate { get; set; }
        [Required]
        [DefaultValue("")]
        public string CommentContent { get; set; }
        public string CommentUserName { get; set; }
        public string PostId { get; set; }
        public string UserId { get; set; }
        public virtual WSocialMediaUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}
