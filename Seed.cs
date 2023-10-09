using SpendBuddy.Data;
using SpendBuddy.Models;

namespace SpendBuddy
{
    public class Seed
    {
        internal DataContext _context;
        internal Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if (!_context.Logs.Any())
            {
                var logs = new List<Log>()
                {
                    new Log
                    {
                        Description = "Walmart",
                        DateAdded = DateTime.Now,
                        DateCharged = DateTime.Now,
                        Cost = 100,
                    },
                    new Log
                    {
                        Description = "Gas",
                        DateAdded = DateTime.Now,
                        DateCharged = DateTime.Now,
                        Cost = 109,
                    },
                    new Log
                    {
                        Description = "Food",
                        DateAdded = DateTime.Now,
                        DateCharged = DateTime.Now,
                        Cost = 22
                    }
                };
                _context.Logs.AddRange(logs);
                _context.SaveChanges();
            }
        }
    }
}