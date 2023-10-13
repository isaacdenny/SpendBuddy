using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SpendBuddy.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private static IConfiguration _config;
        DataContext IDesignTimeDbContextFactory<DataContext>.CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _config = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
            optionsBuilder.UseMySql(_config.GetConnectionString("MYSQLDevConnection"), serverVersion);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
