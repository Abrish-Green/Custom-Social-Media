using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Like
    {
        [Key]
        public string Id { get; set; }
      
        public Post Post { get; set; }
        public string UsersId { get; set; }
    }
}
