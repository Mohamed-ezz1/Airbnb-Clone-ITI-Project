using Airbnb.BL;
using Airbnb.DAL;
using Airbnb.DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Airbnb.API;

var builder = WebApplication.CreateBuilder(args);

b




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DataBase
builder.Services.AddDbContext<AircbnbContext>(options =>
 options.UseSqlServer("Server=.; Database=AirBnb; Trusted_Connection=true; Encrypt=false;"));
#endregion

#region Identity

//Mainly specify the context and the type of the user that the UserManger will use
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<AircbnbContext>();


#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "row"; // For Authentication
    options.DefaultChallengeScheme = "row"; //To Handle Challenge
})
    .AddJwtBearer("row", options =>
    {
        //Use this key when validating requests
        var keyString = builder.Configuration.GetValue<string>("SecretKey");
        var keyInBytes = Encoding.ASCII.GetBytes(keyString!);
        var key = new SymmetricSecurityKey(keyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

#endregion

#region MyRegion


builder.Services.AddScoped<IGuestSectionManager, GuestSectionManager>();
builder.Services.AddScoped<IGuestSectionRepo, GuestSectionRepo>();
builder.Services.AddScoped<IUserHostRepo, UserHostRepo>();
builder.Services.AddScoped<IHostSectionManagers, HostSectionManagers>();
builder.Services.AddScoped<ISearchBarManger, SearchBarManger>();
builder.Services.AddScoped<ICountriesRepositories, CountriesRepositories>();
builder.Services.AddScoped<IUserDetailsRepositories, UserDetailsRepositories>();
builder.Services.AddScoped<IUserMangers, UserMangers>();

builder.Services.AddScoped<IHomeManager, HomeManager>();
builder.Services.AddScoped<IHstPropertyRepo, HstPropertyRepo>();
builder.Services.AddScoped<IPropertyDetailsRepo, PropertyDetailsRepo>();

builder.Services.AddScoped<IPropertyManager, PropertyManager>();

builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICounrtyRepo, CountryRepo>();
builder.Services.AddScoped<IAmenityRepo, AmenitiesRepo>();
builder.Services.AddScoped<IHstPropRepo, HstPropRepo>();


builder.Services.AddScoped<IHostPropertyManager, HostPropertyManager>();



//builder.Services.AddScoped<NoCollidingDateRangeAttribute>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


