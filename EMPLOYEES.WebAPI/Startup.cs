using EMPLOYEES.DAL.DataModel;
using EMPLOYEES.Repository;
using EMPLOYEES.Repository.Common;
using EMPLOYEES.Service;
using EMPLOYEES.Service.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EMPLOYEES.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Konfiguriranje DbContext-a za rad sa SQL serverom
            services.AddDbContext<EMPLOYEES_DbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EMPLOYEES_DBConnection")));

            //dodavanje servisnog sloja u Dependency Injection kontejner
            //Registrira implementaciju Service.Service za suèelje IService.
            //Kada se IService ubrizgava u konstruktor, DI kontejner æe koristiti ovu implementaciju
            services.AddScoped<IService, Service.Service>();

            services.AddScoped<IRepository, Repository.Repository>();
            services.AddScoped<IRepositoryMappingService, RepositoryMappingService>();

            //services.AddSingleton<IRepository, Repository.Repository>();

            //services.AddSingleton<IRepositoryMappingService, RepositoryMappingService>();


            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:5173") // Dozvoljava pristup s odreðenog URL-a
                                      .AllowAnyHeader() // Dozvoljava sve zaglavlja
                                      .AllowAnyMethod()); // Dozvoljava sve HTTP metode
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowSpecificOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
