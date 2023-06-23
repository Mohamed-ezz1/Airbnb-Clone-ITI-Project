using Airbnb.BL;
using Airbnb.DAL;
using Airbnb.DAL.Data;
using Airbnb.DAL.Repositories.GuestsSectionRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AircbnbContext>(options =>
 options.UseSqlServer("Server=.; Database=AirBnb; Trusted_Connection=true; Encrypt=false;"));

builder.Services.AddScoped<IGuestSectionManager, GuestSectionManager>();
builder.Services.AddScoped<IGuestSectionRepo, GuestSectionRepo>();


builder.Services.AddScoped<IUserHostRepo, UserHostRepo>();
builder.Services.AddScoped<IHostSectionManagers, HostSectionManagers>();
builder.Services.AddScoped<ISearchBarManger, SearchBarManger>();
builder.Services.AddScoped<ICountriesRepositories, CountriesRepositories>();
builder.Services.AddScoped<IUserDetailsRepositories, UserDetailsRepositories>();
builder.Services.AddScoped<IUserMangers, UserMangers>();

builder.Services.AddScoped<IHomeManager, HomeManager>();
builder.Services.AddScoped<IPropertyRepo, PropertyRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


