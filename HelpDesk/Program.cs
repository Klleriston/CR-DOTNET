using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://+:8080");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CrDB>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("c")));
builder.Services.AddScoped<JWTservice>(sp => new JWTservice(builder.Configuration["JWTSettings:SecretKey"]));
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<TicketService>();

var app = builder.Build();

app.UseCors("AllowMyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
