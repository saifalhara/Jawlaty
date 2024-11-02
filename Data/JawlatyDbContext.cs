using System;
using System.Numerics;
using Jawlaty.Auth;
using Jawlaty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jawlaty.Data
{
	public class JawlatyDbContext : IdentityDbContext<ApplicationUser>
    {
		

        public JawlatyDbContext(DbContextOptions options): base(options)
        {


        }

        //public DbSet<User> YourEntities { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Entertainment> Entertainments { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Venue> Venue { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



       
            SeedRole(modelBuilder, "Admin");
            SeedRole(modelBuilder, "User");

            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gamil.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
            };
            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "admin",
                UserId = "1"
            });





            modelBuilder.Entity<City>().HasData(
              new City { Id = 1, Name = "Amman" },
              new City { Id = 2, Name = "Irbid" },
              new City { Id = 3, Name = "Zarqa" },
              new City { Id = 4, Name = "Aqaba" },
              new City { Id = 5, Name = "Madaba" },
              new City { Id = 6, Name = "Jerash" },
              new City { Id = 7, Name = "Salt" },
              new City { Id = 8, Name = "Mafraq" },
              new City { Id = 9, Name = "Karak" },
              new City { Id = 10, Name = "Tafilah" },
              new City { Id = 11, Name = "Ma'an" },
              new City { Id = 12, Name = "Ajloun" }
              );

 

        }





        private void SeedRole(ModelBuilder modelBuilder, string roleName)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
        }
    }
}