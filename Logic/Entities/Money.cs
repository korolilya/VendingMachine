using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Money
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }

        public string MoneyInfo
        {
            get
            {
                return $"{Value}₽ ({Quantity})";
            }
        }
    }
}
