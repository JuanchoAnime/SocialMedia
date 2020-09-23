namespace SocialMedia
{
    using System;
    using AutoMapper;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using SocialMedia.Core.Custom;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Core.Interfaces.Repository;
    using SocialMedia.Core.Interfaces.Service;
    using SocialMedia.Core.Services;
    using SocialMedia.Infrastructure.Data;
    using SocialMedia.Infrastructure.Filters;
    using SocialMedia.Infrastructure.Interfaces;
    using SocialMedia.Infrastructure.Repositories;
    using SocialMedia.Infrastructure.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => {
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            }).ConfigureApiBehaviorOptions(options => {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<SocialMediaContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("ApiContext"));
            });
            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));

            // Repositories
            services.AddTransient<IPublishRepository, PublishRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            //Services
            services.AddTransient<IPublicationService, PublicationService>();
            services.AddSingleton<IUriService>(provider =>
            {
                var acceso = provider.GetRequiredService<IHttpContextAccessor>();
                var request = acceso.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(swagger=> {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Social Media API", Version = "1" });
            });
            services.AddMvc(options => {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Socila Media API");
                options.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
