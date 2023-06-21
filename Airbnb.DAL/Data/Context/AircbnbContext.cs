using Airbnb.DAl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL.Data;

public class AircbnbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{

    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<Booking>  Bookings => Set<Booking>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<PropertyAmenity> PropertyAmenities => Set<PropertyAmenity>();
    public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();
    public DbSet<PropertyRule> PropertyRules => Set<PropertyRule>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Rule> Rules => Set<Rule>();
    public DbSet<User> Users => Set<User>();

      public AircbnbContext(DbContextOptions<AircbnbContext> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder Builder)
    {
        base.OnModelCreating(Builder);

        Builder.Entity<IdentityUser>().UseTptMappingStrategy();


        #region Propery

        Builder.Entity<Property>()
            .HasOne(x => x.User)
            .WithMany(b => b.UserProperties)
            .HasForeignKey(y=> y.UserId);


        Builder.Entity<Property>()
            .HasOne(x => x.Category)
            .WithMany(b => b.CategoryProperties)
            .HasForeignKey(y => y.CategoryId);


        Builder.Entity<Property>()
            .HasOne(x => x.City)
            .WithMany(b => b.CityProperties)
            .HasForeignKey(y => y.CityId);




        #endregion

        #region Propery-Aminties
        Builder.Entity<PropertyAmenity>().HasOne(P => P.Property).WithMany(P => P.PropertyAmenities).HasForeignKey(P => P.PropertyId);

        Builder.Entity<PropertyAmenity>().HasOne(P => P.Amenity).WithMany(P => P.AmenitiesProperty).HasForeignKey(P => P.AmenityId);
        Builder.Entity<PropertyAmenity>().HasKey(p => new { p.PropertyId , p.AmenityId});

        #endregion

        #region Catogrey 


        #endregion

        #region PropertyRule 

        Builder.Entity<PropertyRule>().HasOne(p => p.Rule).WithMany(p => p.RuleProperty).HasForeignKey(p=>p.RuleId);
        Builder.Entity<PropertyRule>().HasOne(p=>p.Property).WithMany(p=>p.PropertyRules).HasForeignKey(p=>p.PropertyId);
        Builder.Entity<PropertyRule>().HasKey(p => new { p.PropertyId, p.RuleId });



        #endregion

        #region BOOKING 
        Builder.Entity<Booking>().HasIndex(p => new {p.UserId, p.PropertyId , p.CheckInDate}).IsUnique();
        Builder.Entity<Booking>().HasOne(p => p.Property).WithMany(p => p.PropertyBookings).HasForeignKey(p => p.PropertyId);
        Builder.Entity<Booking>().HasOne(p => p.User).WithMany(p => p.UserBookings).HasForeignKey(p => p.UserId);
        #endregion

        #region Users


        #endregion

        #region city
        Builder.Entity<City>().HasOne(p => p.Country).WithMany(p => p.Cities).HasForeignKey(p => p.CounrtyId);


        #endregion

        #region Propery_img
        Builder.Entity<PropertyImage>().HasOne(p=>p.Property).WithMany(p=>PropertyImages).HasForeignKey(p => p.PropertyId); 
        Builder.Entity<PropertyImage>().HasOne(P=>P.User).WithMany(P=>P.UserPropertyImages).HasForeignKey(p => p.UserId);
        #endregion

        #region review 
        Builder.Entity<Review>().HasOne(p=>p.User).WithMany(p=>p.Reviews).HasForeignKey(p=>p.UserId);
        Builder.Entity<Review>().HasOne(p => p.Property).WithMany(p => p.Reviews).HasForeignKey(p => p.PropertyId);
        Builder.Entity<Review>().HasOne(p => p.Booking).WithMany(p => p.Reviews).HasForeignKey(p => p.BookingId);
         Builder.Entity<Review>().HasKey(p =>new { p.BookingId ,p.PropertyId,p.UserId});


        #endregion


    }
}
