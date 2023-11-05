using AutoMapper;
using Invoices.Handler;
using Invoices.Model;
using Invoices.Services;
using Invoices.Services.Interfaces;
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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<IClientService, ClientService>();
            var connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            var automapper = new MapperConfiguration(item => item.AddProfile(new MappingProfile()));
            IMapper mapper = automapper.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IProductService, ProductService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
