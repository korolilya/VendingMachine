using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UnpopularProdViewModel
    {
        public string Name { get; set; }
        public int QuantitySold { get; set; }

        public string Info
        {
            get
            {
                return $"{Name}: {QuantitySold} items sold";
            }
        }
    }
}
