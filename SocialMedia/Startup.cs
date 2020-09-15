using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using SocialMedia.Infrastructure.Repositories;

namespace SocialMedia
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {  Configuration = configuration; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers();
            services.AddDbContext<SocialMediaContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("ApiContext"));
            });
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPublishRepository, PublishRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
