using AutoMapper;
using HomeCash.Application.CommandHandlers;
using HomeCash.Application.Services;
using HomeCash.Domain.AutoMapperProfiles;
using HomeCash.Domain.RepositoryContracts;
using HomeCash.Infrastructure.EFCore.DbContexts;
using HomeCash.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HomeCash.API
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
            services.AddControllers();
            RegisterInterfaces(services);
            RegisterDbContext(services);
            RegisterTokenService(services);
            RegisterMediatR(services);
            RegisterAutoMapper(services);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterTokenService(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });
        }

        private void RegisterInterfaces(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICostRepository, CostRepository>();
            services.AddScoped<IHomeBaseRepository, HomeBaseRepository>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

        }

        private void RegisterDbContext(IServiceCollection services)
        {
            services.AddDbContext<HomeCashDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("HomeCashDbContext"));
            });
        }

        private void RegisterMediatR(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly);
        }

        private void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        }
    }
}