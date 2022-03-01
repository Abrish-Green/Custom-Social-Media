using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Models
{
    [Keyless]

    public class Information
    {
       [Required]
       public string Phone { get; set; }

       [Required]
       [DataType(DataType.Date)]
       public DateTime BirthDate { get; set; }
    
       [Required]
       [EmailAddress]
       public string Email { get; set; }
       
       [Required]
       public string Address { get; set; }
       
       [Required]
       public string Job { get; set; }

       [Required]
       public string Sex { get; set; }
        
       public string? ProfilePictureUrl { get; set; }
       
       public string UserId { get; set; }
    }
}
