using System;
using System.Reflection;
using System.Text.Json.Serialization;
using LapTopShop.API.Extensions;
using LapTopShop.API.Middlewares;
using LapTopShop.DAL.Contexts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LapTopShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            bool.TryParse(Configuration["BaseServiceSettings:UseInMemoryDatabase"], out var useInMemory);

            if (!useInMemory)
            {
                services.AddDbContext<LapTopDataBaseContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("LapTopDatabase"), b => b.MigrationsAssembly("LapTopShop.DAL"));
                });
            }
            else
            {
                services.AddDbContext<LapTopDataBaseContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            }

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var actionExecutingContext =
                        actionContext as ActionExecutingContext;

                    if (actionContext.ModelState.ErrorCount > 0
                        && actionExecutingContext?.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
                    {
                        return new UnprocessableEntityObjectResult(actionContext.ModelState);
                    }

                    return new BadRequestObjectResult(actionContext.ModelState);
                };
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.RegisterRepositoies();
            services.RegisterServices();
            services.AddSwaggerDocumentation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }

            app.UseMiddleware<ExceptionMiddleware>();
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
