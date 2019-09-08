using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProfitViewModel
    {
        public string Location { get; set; }
        public double Profit { get; set; }

        public string Info
        {
            get
            {
                return $"{Location}: with total profit {Profit}";
            }
        }
    }
}
