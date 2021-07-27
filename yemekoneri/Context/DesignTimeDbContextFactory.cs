using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace yemekoneri.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<YemekOneriDbContext>
    {
        public YemekOneriDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<YemekOneriDbContext> builder = new DbContextOptionsBuilder<YemekOneriDbContext>();
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .Build();
            builder.UseSqlServer(config.GetConnectionString("DefaultConnectionString"));
            return new YemekOneriDbContext(builder.Options);
        }
    }
}
