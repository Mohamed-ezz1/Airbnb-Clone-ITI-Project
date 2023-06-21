using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.DAl;

public class Property
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int BathroomCount { get; set; }
    public int RoomCount { get; set; }
    public int BedCount { get; set; }
    public string Longitude { get; set; } = string.Empty;
    public string Latitude { get; set; } = string.Empty;
    public bool AvailabilityType { get; set; }
    public double PricePerNight { get; set; }
    public int MaximumNumberOfGuests { get; set; }
    public IEnumerable<PropertyAmenity> PropertyAmenities { get; set; } = new List<PropertyAmenity>();
    public IEnumerable<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
    public IEnumerable<Booking> PropertyBookings { get; set; } = new List<Booking>();
    public IEnumerable<PropertyRule> PropertyRules { get; set; } = new List<PropertyRule>();
    public int CategoryId { get; set; }
    public Category Category { get; set; } = new();
    public int CountryId { get; set; }
    public Country Country { get; set; } = new();
    public int CityId { get; set; }
    public City City { get; set; } = new();
}
