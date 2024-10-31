using System.Collections.Generic;
using Jawlaty.Auth;
using Jawlaty.Auth.Services;
using Jawlaty.Data;
using Jawlaty.Services;
using Jawlaty.Services.Rating;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSession();

string connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services
    .AddDbContext<JawlatyDbContext>
(opions => opions.UseSqlServer(connString));



// Register services
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<IUserFavoriteService, UserFavoriteService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IEntertainmentService, EntertainmentService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ITransportationService, TransportationService>();
builder.Services.AddScoped<IVenueService, VenueService>();



//builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

builder.Services.AddMvc();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<JawlatyDbContext>();


// failed trials - accessing path
// new for cookies auth
builder.Services.ConfigureApplicationCookie(option =>
{
    option.AccessDeniedPath = "/auth/index";
});

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();


builder.Services.AddTransient<IUser, UserServices>();


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
app.UseSession();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();