using Hiper.Commerce.Api.Data;
using Hiper.Commerce.Api.Repositories.Token;
using Hiper.Commerce.Api.Repositories.User;
using Hiper.Commerce.Api.Services.Product;
using Hiper.Commerce.Api.Services.Token;
using Hiper.Commerce.Api.Services.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace Hiper.Commerce.Api
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
            services.AddCors(p => p.AddPolicy("CorsPolicy", build => 
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ITokenServices, TokenServices>();

            services.AddControllers();
            services.AddDbContext<HiperCommerceContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hiper.Commerce.Api", Version = "v1" });
            });

            var httpClientServices = new List<string>
            {
                nameof(TokenServices),
                nameof(ProductServices),
            };

            foreach (var client in httpClientServices)
            {
                services.AddHttpClient(client, options => options.BaseAddress = new Uri("http://ms-ecommerce.hiper.com.br/api/v1/"));
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hiper.Commerce.Api v1"));
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
