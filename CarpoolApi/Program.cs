using CarPool.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens; 
using Carpool.Repository.Interface;
using Carpool.Repository;
using Carpool.Services.Interaface;
using Carpool.Services;
using Carpool.Services.Interface;
using AutoMapper;
using CarpoolApi.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy", policy =>
{
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddScoped<IBookedRidesService, BookedRidesService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IMatchingRidesService,MatchingRidesService>();
builder.Services.AddScoped<IOfferRideService, OfferRideService>();
builder.Services.AddScoped<IUserDetailsService, UserDetailsService>();
builder.Services.AddScoped<IUserDetailsRepository, UserDetailsRepository>();
builder.Services.AddScoped<IBookedRideRepository, BookedRideRepository>();
builder.Services.AddScoped<IOfferRideRepository, OfferRideRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnStr"));
});
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ApplicationMapper());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddControllersWithViews();

var TokenValidationParameters = new TokenValidationParameters()
{
    ValidateIssuer = true,
    ValidateAudience = true,
    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
    ClockSkew = TimeSpan.FromMinutes(2)
};
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(cfg =>
{
    cfg.TokenValidationParameters = TokenValidationParameters;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use authentication before authorization
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();

app.Run();
