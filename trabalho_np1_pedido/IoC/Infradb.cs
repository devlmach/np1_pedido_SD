using Microsoft.EntityFrameworkCore;
using trabalho_np1_pedido.Application.Service;
using trabalho_np1_pedido.Application.Service.Interface;
using trabalho_np1_pedido.Data.Context;
using trabalho_np1_pedido.Data.Repository;
using trabalho_np1_pedido.Data.Repository.Interface;

namespace trabalho_np1_pedido.IoC
{
    public static class Infradb
    {
        public static IServiceCollection AddInfraDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            var licenseKey = Environment.GetEnvironmentVariable("AUTOMAPPER_LICENSE_KEY")
                ?? configuration["AutoMapperLicenseKey"];

            services.AddAutoMapper(cfg =>
            {
                if (!string.IsNullOrEmpty(licenseKey))
                    cfg.LicenseKey = licenseKey;
            });

            return services;
        }
    }
}
