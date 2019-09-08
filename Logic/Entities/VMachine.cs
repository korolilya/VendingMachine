using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class VMachine
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public List<FilledVM> Products { get; set; }
        public List<Money> Money { get; set; }
        public List<DailyStatistic> DailyStatistics { get; set; }       
    }
}
