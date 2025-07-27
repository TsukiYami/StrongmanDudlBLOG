using BackendStrongmanDudlBLOG.DB;
using Microsoft.EntityFrameworkCore;

namespace BackendStrongmanDudlBLOG.Program;

public class Startup
{
    public IConfiguration oConfiguration { get; private set; }
    
    public Startup(IConfiguration oConfiguration)
    {
        this.oConfiguration = oConfiguration;
    }

    public void ConfigureServices(IServiceCollection oServices)
    {
        oServices.AddDbContext<BlogContext>(options =>
            options.UseNpgsql("Host=host.docker.internal,5432; Database=strongmandudlblog_db; Username=admin; Password=password"));
        
        oServices.AddControllers();
        oServices.AddEndpointsApiExplorer();
    }

    public void Configure(IApplicationBuilder oApp, IWebHostEnvironment oWHEnv)
    {
        if (oWHEnv.IsDevelopment())
        {
            oApp.UseDeveloperExceptionPage();
        }
        
        oApp.UseRouting();
        oApp.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}