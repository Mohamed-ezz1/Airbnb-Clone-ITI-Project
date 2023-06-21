using Airbnb.DAl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL.Data;

public class AircbnbContext : DbContext
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}
