using RefactorBEcapstone.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RefactorBEcapstone.Models;
using RefactorBEcapstone;
using RefactorBEcapstone.Repositories;
using RefactorBEcapstone.Service;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RefactorDbContext>(options =>
    options.UseNpgsql(connectionString, x => {
        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }));

builder.Services.Configure<IdentityOptions>(options => {
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Lockout = new LockoutOptions() { MaxFailedAccessAttempts = 10 };
});

builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<RefactorDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Google:ClientId"];
    options.ClientSecret = builder.Configuration["Google:Secret"];
    options.SignInScheme = IdentityConstants.ExternalScheme;
    options.SaveTokens = true;
});

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("default", options =>
    {
        options.WithOrigins("http://localhost:3000", "https://localhost:5173", 
                            "https://localhost:5200", "https://discord.com", 
                            "https://localhost:3000", "https://localhost:7202")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = true);

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IGenericRepository<ChristmasYear>, GenericRepository<ChristmasYear>>();
builder.Services.AddTransient<IChristmasYearService, ChristmasYearService>();
builder.Services.AddTransient<IGenericRepository<ChristmasList>, GenericRepository<ChristmasList>>();
builder.Services.AddTransient<IListService, ListService>();
builder.Services.AddTransient<IGenericRepository<AppUser>, GenericRepository<AppUser>>();
builder.Services.AddTransient<IGenericRepository<Gift>, GenericRepository<Gift>>();
builder.Services.AddTransient<IGiftService, GiftService>();
builder.Services.AddTransient<IGenericRepository<Giftee>, GenericRepository<Giftee>>();
builder.Services.AddTransient<IGifteeService, GifteeService>();


var app = builder.Build();

app.MapIdentityApi<AppUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
