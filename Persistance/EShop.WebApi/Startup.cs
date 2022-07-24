using EShop.Domain;
using EShop.Domain.Core;
using EShop.Domain.Interfaces;
using EShop.Infrastructure.Auth;
using EShop.Infrastructure.Data.Context;
using EShop.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace EShop.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddDbContext<EShopContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtOptions>(
                Configuration.GetSection("JwtOptions"));
            
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<ProductCategory>, ProductCategoryRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IAuthHashGenerator, TokenGenerator>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddSwaggerGen();


        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
