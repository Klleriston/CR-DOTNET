using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://+:8080");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CrDB>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("c")));
builder.Services.AddScoped<JWTservice>(sp => new JWTservice(builder.Configuration["JWTSettings:SecretKey"]));
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<ITicketRepository, TicketService>();

var app = builder.Build();

app.UseAuthorization();



app.MapControllers();

app.Run();