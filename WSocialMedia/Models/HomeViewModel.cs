using SocialMedia.Models;
using System.ComponentModel.DataAnnotations;
using WSocialMedia.Areas.Identity.Data;

namespace WSocialMedia.Models
{
    public class HomeViewModel
    {
        public string postId { get; set; }
        public string UserName { get; set; }
        public string PostContent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
