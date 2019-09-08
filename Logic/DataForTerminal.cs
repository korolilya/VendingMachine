using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DataForTerminal
    {
        public static List<Money> GetMoney()
        {
            return new List<Money>
            {
                new Money{Value=1, Quantity=100},
                new Money{Value=2, Quantity=100},
                new Money{Value=5, Quantity=50},
                new Money{Value=10, Quantity=50},
            };
        }

    }
}
