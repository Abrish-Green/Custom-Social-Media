using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WSocialMedia.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WSocialMediaUser class
public class WSocialMediaUser : IdentityUser
{

    public static implicit operator WSocialMediaUser(DbSet<WSocialMediaUser> v)
    {
        throw new NotImplementedException();
    }
}

