using BestPractices.Api.Service;
using BestPractices.API.BackgroundServices;
using BestPractices.API.Extensions;
using BestPractices.API.Models;
using BestPractices.API.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BestPractices.API
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
            services.AddControllers().AddFluentValidation(i => i.RunDefaultMvcValidationAfterFluentValidationExecutes = false);

            services.AddHealthChecks();

            services.ConfigureMapping();

            services.AddTransient<IValidator<ContactDVO>, ContactValidation>();

            services.AddScoped<IContactService, ContactService>();

            services.AddHttpClient("garantiApi", config =>
            {
                config.BaseAddress = new System.Uri("http://www.garanti.com");
                config.DefaultRequestHeaders.Add("Authorization", "Bearer 21212");

            });

            services.AddHostedService<DateTimeLogWriter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomHealthCheck();

            app.UseResponseCaching();

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
