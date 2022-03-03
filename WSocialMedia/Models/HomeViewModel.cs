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
        public IEnumerable<Like> Likes { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
