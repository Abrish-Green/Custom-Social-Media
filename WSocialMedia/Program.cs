using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using WSocialMedia.Areas.Identity.Data;
using WSocialMedia.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WSocialMediaConnection");
builder.Services.AddDbContext<WSocialMediaContext>(options =>
    options.UseNpgsql(connectionString));builder.Services.AddDefaultIdentity<WSocialMediaUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WSocialMediaContext>();

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(o =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    o.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SocialMediaApp}/{action=Index}");

app.Run();
