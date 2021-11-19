using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GolfScores.DB;
using GolfScores.Services;
using GolfScores.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName;

namespace GolfScores.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment currentEnvironment)
        {
            Configuration = configuration;
            CurrentEnvironment = currentEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            if (!CurrentEnvironment.IsEnvironment("Testing"))
            {
                services.AddDbContext<GolfScoresDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString(nameof(GolfScoresDbContext))));
            }

            services.AddTransient<ICourseDataIntegrationServices, CourseDataIntegrationServices>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GolfScores.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GolfScoresDbContext golfScoresDbContext)
        {
            if (!env.IsEnvironment("prd") && !CurrentEnvironment.IsEnvironment("Testing"))
            {
                golfScoresDbContext.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GolfScores.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
