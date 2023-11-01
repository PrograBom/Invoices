using AutoMapper;
using Invoices.Handler;
using Invoices.Model;
using Invoices.Services;
using Microsoft.EntityFrameworkCore;

namespace Invoices
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Default");
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<IClientService, ClientService>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
            ServiceLifetime.Transient);
            var automapper = new MapperConfiguration(item => item.AddProfile(new MappingProfile()));
            IMapper mapper = automapper.CreateMapper();
            services.AddSingleton(mapper);
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
