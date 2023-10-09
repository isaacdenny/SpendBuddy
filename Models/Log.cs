using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpendBuddy.Models
{
    [Table(name:"Logs")]
    internal class Log
    {
        [Key]
        public int ID { get; set; }
        public string Description {  get; set; }
        public double Cost { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateCharged { get; set; }
    }
}
