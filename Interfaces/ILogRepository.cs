using SpendBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendBuddy.Interfaces
{
    internal interface ILogRepository
    {
        Log GetLog(int id);
        ICollection<Log> GetLogs();
        // GetLogsByMonth or GetLogs with limit
    }
}
