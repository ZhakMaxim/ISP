using _253504_Zhak.Persistense.Data;
using _253504_Zhak.Persistense.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Zhak.Persistense
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            //services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IRepository<Author>, EfRepository<Author>>();
            services.AddTransient<IRepository<Book>, EfRepository<Book>>();
            services.AddScoped<AppDbContext>();
            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options)
        {
            services.AddPersistence()
            .AddSingleton<AppDbContext>(
           new AppDbContext((DbContextOptions<AppDbContext>)options));
            return services;
        }
    }

}
