using Airbnb.BL;
using Airbnb.DAL;
using Airbnb.DAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AircbnbContext>(options =>
 options.UseSqlServer("Server=DESKTOP-34KGDF7\\MSSQLSERVER01; Database=AirBnb; Trusted_Connection=true; Encrypt=false;"));


builder.Services.AddScoped<IUserHostRepo, UserHostRepo>();
builder.Services.AddScoped<IHostSectionManagers, HostSectionManagers>();
builder.Services.AddScoped<ISearchBarManger, SearchBarManger>();
builder.Services.AddScoped<ICountriesRepositories, CountriesRepositories>();
builder.Services.AddScoped<IUserDetailsRepositories, UserDetailsRepositories>();
builder.Services.AddScoped<IUserMangers, UserMangers>();


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


