using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using testauthcookiegoogle.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme; // Use Google as the default external provider
})
        .AddCookie()
        .AddGoogle(options =>
        {
            options.ClientId = "513475469262-4n0tanqtkhhgrelkdagioukseroe3ls1.apps.googleusercontent.com";
            options.ClientSecret = "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";
        });
builder.Services.AddDbContext<dbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppCon")));
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
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=cruds}/{action=Index}/{id?}");

app.Run();
