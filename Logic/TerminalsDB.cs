using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class TerminalsDB : DbContext
    {
        public DbSet<VMachine> VMachines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DailyStatistic> DailyStatistics { get; set; }
        public DbSet<Money> Money { get; set; }
        



        public TerminalsDB() : base("localsql") { }
    }
}
