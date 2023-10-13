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
                        DateCharged = Convert.ToDateTime("10/03/2023"),
                        Cost = 120.00,
                        Category = Category.GROCERY
                    },
                    new Log
                    {
                        Description = "Gas",
                        DateAdded = DateTime.Now,
                        DateCharged = Convert.ToDateTime("10/04/2023"),
                        Cost = 109.00,
                        Category = Category.GAS
                    },
                    new Log
                    {
                        Description = "Chickfila",
                        DateAdded = DateTime.Now,
                        DateCharged = Convert.ToDateTime("10/05/2023"),
                        Cost = 22.00,
                        Category = Category.OTE
                    }
                };
                _context.Logs.AddRange(logs);
                _context.SaveChanges();
            }
        }
    }
}