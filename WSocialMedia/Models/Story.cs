using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Models
{
    public class Story
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string PostContent { get; set; }

        public DateTime PostedDate { get; set; }



    }
}
