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
            string input = "m";
            while (input != "q")
            {
                switch(input)
                {
                    case "m":
                        ShowMenu();
                        break;
                    case "s":
                        WriteLogs();
                        break;
                    case "a":
                        AddLog();
                        break;
                    case "d":
                        DeleteLog();
                        break;
                    case "i":
                        ImportLogs();
                        break;
                    default: 
                        break;
                }
                Console.Write("sb control >> ");
                input = Console.ReadLine().ToLower();
            }
        }

        private static void ImportLogs()
        {
            Console.WriteLine("*** Import Logs From CSV ***");
            Console.Write("Path to file: ");
            string filePath = Path.GetFullPath(Console.ReadLine());

            try
            {
                using(var sr = new StreamReader(filePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: File not found");
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("*** Menu ***\n");
            Console.WriteLine("[S]how logs");
            Console.WriteLine("[A]dd log");
            Console.WriteLine("[D]elete log");
            Console.WriteLine("[I]mport logs from csv");
            Console.WriteLine("[E]xport logs to csv");
            Console.WriteLine();
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

            double total = 0;
            Console.WriteLine();
            Console.WriteLine("{0,10}{1,10}{2,20}{3,10}","ID","Date","Description","Cost");
            foreach (var l in logs)
            {
                total += l.Cost;
                Console.WriteLine("{0,10}{1,10}{2,20}{3,10}", l.ID, l.DateCharged.Month + "/" + l.DateCharged.Day, l.Description,"$" + l.Cost);
            }
            Console.WriteLine();
            Console.WriteLine("{0,50}", "Total: $" + total);
            Console.WriteLine();
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
            Console.WriteLine();
        }

        static void DeleteLog()
        {
            Console.WriteLine("*** Delete a log ***\n");
            Console.Write("ID of log to delete: ");
            int id = Convert.ToInt16(Console.ReadLine());

            var lr = new LogRepository(_context);
            int num = lr.DeleteLog(id);

            Console.WriteLine("Deleted: " + num + " logs");
            Console.WriteLine();
        }
    }
}