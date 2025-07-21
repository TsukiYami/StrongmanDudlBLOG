using BackendStrongmanDudlBLOG.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            options.UseNpgsql("Host=host.docker.internal,5432; Database=pnp_db; Username=admin; Password=password"));
        
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