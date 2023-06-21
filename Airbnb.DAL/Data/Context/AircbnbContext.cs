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
    public DbSet<Booking> booking => Set<Amenity>();
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<Amenity> Amenities => Set<Amenity>();



    public AircbnbContext(DbContextOptions<AircbnbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.
    }

}
