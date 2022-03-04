using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace WSocialMedia.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WSocialMediaUser class
public class WSocialMediaUser : IdentityUser
{

    public virtual ICollection<Post> Post { get; set; }

    public static implicit operator WSocialMediaUser(DbSet<WSocialMediaUser> v)
    {
        throw new NotImplementedException();
    }
}

