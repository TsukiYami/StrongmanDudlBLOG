using Microsoft.EntityFrameworkCore;
using BackendStrongmanDudlBLOG.DB;
using BackendStrongmanDudlBLOG.Services;

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Entity Framework konfigurieren
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BlogDB")));

// Services registrieren
builder.Services.AddScoped<LoginService>();

// CORS konfigurieren (wichtig für Frontend-Backend Kommunikation)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAll");
app.UseRouting();
app.MapControllers();

app.Run();*/
namespace BackendStrongmanDudlBLOG.Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://0.0.0.0:5050");
                    webBuilder.UseKestrel();
                });
    }
}