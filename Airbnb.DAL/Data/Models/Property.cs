using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAL;

public class Property
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(25)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
    public int BathroomCount { get; set; }
    public int RoomCount { get; set; }
    public int BedCount { get; set; }
    public decimal?Longitude { get; set; }
    public decimal? Latitude { get; set; } 
    public bool AvailabilityType { get; set; }
    public double PricePerNight { get; set; }
    [Range(1,16)]
    public int MaximumNumberOfGuests { get; set; }
    public IEnumerable<PropertyAmenity> PropertyAmenities { get; set; } = new List<PropertyAmenity>();
    public IEnumerable<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
    public IEnumerable<Booking> PropertyBookings { get; set; } = new List<Booking>();
    public IEnumerable<PropertyRule> PropertyRules { get; set; } = new List<PropertyRule>();
    public IEnumerable<Review> Reviews { get; set; } = new List<Review>();

    public string? UserId { get; set; }
    public User? User { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; } 
    public int? CityId { get; set; }
    public City? City { get; set; }
     public int NumberOfReview
     {
        get { return Reviews?.Count() ?? 0; }
     }
    [Range(0,5)]
    public double OverALLReview
    {
        get { return Reviews?.Average(review => review.Rate) ?? 0.0; }
    }

    public bool isAvailable { get; set; } = true;
}
