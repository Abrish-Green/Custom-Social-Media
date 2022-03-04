using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;
using WSocialMedia.Areas.Identity.Data;

namespace WSocialMedia.Data;

public class WSocialMediaContext : IdentityDbContext<WSocialMediaUser>
{
    public WSocialMediaContext(DbContextOptions<WSocialMediaContext> options)
        : base(options)
    {
    }
    public DbSet<Information> Informations { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Story> Storys { get; set; }
    public DbSet<Friends> MyFriends { get; set; }
    public DbSet<Followers> MyFollowers { get; set; }
    public DbSet<Following> MyFollowings { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Notification> Notificaitons { get; set; }
    public DbSet<Like> Likes { get; set; } 
    public DbSet<Comment> Comments { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
