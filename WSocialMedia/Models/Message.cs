using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Models
{
    [Keyless]

    public class Message
    {
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public string? TextMessage { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime MessageDateInformation { get; set; }

    }
}
