using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpendBuddy.Data;
using SpendBuddy.Models;
using SpendBuddy.Repositories;

namespace SpendBuddy
{
    class Program
    {
        private static IConfiguration _config;
        private static DataContext _context;
        static void Main(string[] args)
        {
            GetDataContext();

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
                var seed = new Seed(_context);
                seed.SeedDataContext();
            }

            WriteLogs();
            AddLog();
            WriteLogs();
        }
        static void GetDataContext()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _config = builder.Build();

            var options = new DbContextOptionsBuilder<DataContext>().UseSqlServer(_config.GetConnectionString("DefaultConnection")).Options;
            _context = new DataContext(options);
        }
        static void WriteLogs()
        {
            var lr = new LogRepository(_context);
            var logs = lr.GetLogs();
            foreach (var l in logs)
            {
                Console.WriteLine(l.ID + "    " + l.Description + "    " + l.Cost);
            }
        }

        static void AddLog()
        {
            string? desc, date, cost;

            Console.WriteLine("*** Add a new log ***\n");

            Console.Write("Date (mm/dd/yyyy): ");
            date = Console.ReadLine();
            Console.Write("Desc: ");
            desc = Console.ReadLine();
            Console.Write("Cost ($): ");
            cost = Console.ReadLine();

            var lr = new LogRepository(_context);
            var log = new Log
            {
                Description = desc,
                DateAdded = DateTime.Now,
                DateCharged = Convert.ToDateTime(date),
                Cost = Convert.ToDouble(cost)
            };
            lr.AddLog(log);
            Console.WriteLine("Added New Log");
        }

        static void DeleteLog(int id)
        {
            var lr = new LogRepository(_context);
            int num = lr.DeleteLog(id);
            Console.WriteLine("Deleted: " + num + " logs");
        }
    }
}