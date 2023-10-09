using Microsoft.EntityFrameworkCore;
using SpendBuddy.Data;
using SpendBuddy.Interfaces;
using SpendBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendBuddy.Repositories
{
    internal class LogRepository : ILogRepository
    {
        DataContext _context;
        public LogRepository(DataContext context) 
        { 
            _context = context;
        }

        public Log GetLog(int id)
        {
            return _context.Logs.Where(l => l.ID == id).FirstOrDefault();
        }

        public void AddLog(Log log)
        {
            _context.Logs.Add(log);
            _context.SaveChanges();
        }

        public int DeleteLog(int id)
        {
            return _context.Logs.Where(l => l.ID == id).ExecuteDelete();
        }

        public ICollection<Log> GetLogs()
        {
            return _context.Logs.ToList();
        }
    }
}
