using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CrDB>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("c")));
builder.Services.AddScoped<JWTservice>(sp => new JWTservice(builder.Configuration["JWTSettings:SecretKey"]));
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<ITicketRepository, TicketService>();

var app = builder.Build();

app.UseCors(o => o
    .WithOrigins(new[] { "http://localhost:4200", }) ///PORTA DO FRONTEND ANGULAS
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

app.UseAuthorization();

// var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<CrDB>();
// context.Database.Migrate();

app.MapControllers();

app.Run();