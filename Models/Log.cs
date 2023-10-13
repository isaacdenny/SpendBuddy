using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpendBuddy.Models
{
    enum Category { HEALTH_INS, CAR_INS, CAR_PAY, GAS, GROCERY, RENT, PHONE, STD_LOANS, OTE, GIFTS, SHOPPING, INTERNET, UTIL, TITHE, SAVINGS, OTHER }
    [Table(name: "Logs")]
    internal class Log
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateCharged { get; set; }
        public Category Category { get; set; }
    }
}
