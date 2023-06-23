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

public class AircbnbContext : IdentityDbContext
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
        Builder.Entity<PropertyImage>().HasOne(p=>p.Property).WithMany(p=>p.PropertyImages).HasForeignKey(p => p.PropertyId); 
        Builder.Entity<PropertyImage>().HasOne(P=>P.User).WithMany(P=>P.UserPropertyImages).HasForeignKey(p => p.UserId);
        #endregion

        #region review 
        Builder.Entity<Review>().HasOne(p=>p.User).WithMany(p=>p.Reviews).HasForeignKey(p=>p.UserId);
        Builder.Entity<Review>().HasOne(p => p.Property).WithMany(p => p.Reviews).HasForeignKey(p => p.PropertyId);
        Builder.Entity<Review>().HasOne(p => p.Booking).WithMany(p => p.Reviews).HasForeignKey(p => p.BookingId);
         Builder.Entity<Review>().HasKey(p =>new { p.BookingId ,p.PropertyId,p.UserId});


        #endregion



        var users = new List<User>{
                  new User
                  {
                      Id = Guid.NewGuid().ToString(),
                      FirstName = "John",
                      LasttName = "Doe",
                      UserType = UserType.Host,
                      About = "I am a regular user."
                  },
                  new User
                  {
                      Id = Guid.NewGuid().ToString(),
                      FirstName = "Jane",
                      LasttName = "Smith",
                      UserType = UserType.Guest,
                      About = "I am an admin user."
                  }
                  // Add more seed data as needed
              };

        var rules = new List<Rule>{
                 new Rule
                 {
                     Id = 1,
                     RuleName = "Rule 1"
                 },
                 new Rule
                 {
                     Id = 2,
                     RuleName = "Rule 2"
                 }
             // Add more seed data as needed
             };





        var amenities = new List<Amenity>
               {          new Amenity
                 {
                     Id = 1,
                     Name = "Amenity 1",
                     Icon = "https://example.com/icon1.png"
                 },
                 new Amenity
                 {
                     Id = 2,
                     Name = "Amenity 2",
                     Icon = "https://example.com/icon2.png"
                 }
                 // Add more seed data as needed
               };

        var categories = new List<Category> {
                 new Category
                 {
                     Id = 1,
                     Name = "Category 1"
                 },
                 new Category
                 {
                     Id = 2,
                     Name = "Category 2"
                 }
             // Add more seed data as needed
             };





        var countries = new List<Country> {
                  new Country
                  {
                      Id = 1,
                      CountryName = "Country 1"
                  },
                  new Country
                  {
                      Id = 2,
                      CountryName = "Country 2"
                  }
              // Add more seed data as needed
              };

        var cities = new List<City> {
                   new City
                   {
                       Id = 1,
                       CityName = "City 1",
                       CounrtyId =1// Assuming the country ID is 1 for example purposes
                   },
                   new City
                   {
                       Id = 2,
                       CityName = "City 2",
                       CounrtyId = 1// Assuming the country ID is 2 for example purposes
                   }
                   // Add more seed data as needed
               };

        var properties = new List<Property> {
                  new Property
                  {
                      Id = Guid.NewGuid(),
                      Name = "Property 1",
                      Description = "Description 1",
                      Address = "Address 1",
                      BathroomCount = 2,
                      RoomCount = 3,
                      BedCount = 4,
                      Longitude = 123.456m,
                      Latitude = 78.90m,
                      AvailabilityType = true,
                      PricePerNight = 100.00,
                      MaximumNumberOfGuests = 6,
                      UserId = users[0].Id, // Assuming a valid user ID
                      CategoryId = categories[0].Id, // Assuming a valid category ID
                        CityId = cities[0].Id // Assuming a valid city ID
                  },
                  new Property
                  {
                      Id = Guid.NewGuid(),
                      Name = "Property 2",
                      Description = "Description 2",
                      Address = "Address 2",
                      BathroomCount = 1,
                      RoomCount = 2,
                      BedCount = 2,
                      Longitude = 45.678m,
                      Latitude = 12.34m,
                      AvailabilityType = true,
                      PricePerNight = 80.00,
                      MaximumNumberOfGuests = 4,
                      UserId =users[1].Id, // Assuming a valid user ID
                      CategoryId = categories[1].Id, // Assuming a valid category ID
                     CityId = cities[1].Id // Assuming a valid city ID
                  }
              // Add more seed data as needed
              };
        var bookings = new List<Booking> {
                          new Booking
                          {
                              Id = Guid.NewGuid(),
                              UserId = users[0].Id,
                              PropertyId = properties[0].Id,
                              CheckInDate = DateTime.UtcNow.Date.AddDays(1),
                              CheckOutDate = DateTime.UtcNow.Date.AddDays(8),
                              TotalPrice = 500.00,
                              BookingDate = DateTime.UtcNow,
                              NumberOfGuests = 4
                          },
                          new Booking
                          {
                              Id = Guid.NewGuid(),
                              UserId = users[1].Id,
                              PropertyId = properties[1].Id,
                              CheckInDate = DateTime.UtcNow.Date.AddDays(2),
                              CheckOutDate = DateTime.UtcNow.Date.AddDays(5),
                              TotalPrice = 300.00,
                              BookingDate = DateTime.UtcNow,
                              NumberOfGuests = 2
                          },
                                new Booking
                          {
                              Id = Guid.NewGuid(),
                              UserId = users[1].Id,
                              PropertyId = properties[1].Id,
                              CheckInDate = DateTime.UtcNow.Date.AddDays(2),
                              CheckOutDate = DateTime.UtcNow.Date.AddDays(5),
                              TotalPrice = 300.00,
                              BookingDate = DateTime.UtcNow,
                              NumberOfGuests = 2
                          }
                      // Add more seed data as needed
                      };

        var reviews = new List<Review>
               {
            new Review
            {
                PropertyId =properties[0].Id,
                UserId = users[0].Id,
                BookingId =bookings[0].Id,
                Rate = 4,
                CreatedDate = DateTime.UtcNow,
                Comment = "This property was great!"
            },
            new Review
            {
                PropertyId = properties[1].Id,
                UserId = users[1].Id,
                BookingId = bookings[1].Id,
                Rate = 5,
                CreatedDate = DateTime.UtcNow,
                Comment = "Highly recommended!"
            }
        // Add more seed data as needed
        };




        var propertyRules = new List<PropertyRule>{           new PropertyRule
                  {
                      RuleId = rules[0].Id, // Assuming a valid rule ID
                      PropertyId = properties[0].Id
                      // Assuming a valid property ID
                  },
                  new PropertyRule
                  {
                      RuleId = rules[1].Id, // Assuming a valid rule ID
                      PropertyId = properties[1].Id // Assuming a valid property ID
                  }
              // Add more seed data as needed
              };


        var propertyAmenities = new List<PropertyAmenity>{
                   new PropertyAmenity
                   {
                       PropertyId =properties[0].Id, // Assuming a valid property ID
                       AmenityId = amenities[0].Id // Assuming a valid amenity ID
                   },
                   new PropertyAmenity
                   {
                       PropertyId = properties[1].Id, // Assuming a valid property ID
                       AmenityId = amenities[1].Id // Assuming a valid amenity ID
                   }
                   // Add more seed data as needed
               };

        var propertyImages = new List<PropertyImage>{
               new PropertyImage
               {
                   Id = 1,
                   PropertyId = properties[0].Id, // Assuming a valid property ID
                   Image = "image1.jpg",
                   UserId = users[0].Id, // Assuming a valid user ID
                   CreatedDate = DateTime.Now
               },
               new PropertyImage
               {
                   Id = 2,
                   PropertyId =properties[0].Id, // Assuming a valid property ID
                   Image = "image2.jpg",
                   UserId = users[1].Id, // Assuming a valid user ID
                   CreatedDate = DateTime.Now
               }
           // Add more seed data as needed
           };




        Builder.Entity<Review>().HasData(reviews);
        Builder.Entity<User>().HasData(users);
        Builder.Entity<Rule>().HasData(rules);

        Builder.Entity<Amenity>().HasData(amenities);
        Builder.Entity<Category>().HasData(categories);
         Builder.Entity<City>().HasData(cities);

        Builder.Entity<Country>().HasData(countries);
        Builder.Entity<Property>().HasData(properties);
        Builder.Entity<Booking>().HasData(bookings);


        Builder.Entity<PropertyRule>().HasData(propertyRules);
        Builder.Entity<PropertyAmenity>().HasData(propertyAmenities);
        Builder.Entity<PropertyImage>().HasData(propertyImages);






    }
}
