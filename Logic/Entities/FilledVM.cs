using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FilledVM
    {
        public int Id { get; set; }
        public VMachine FVMachine { get; set; }
        public Product Product { get; set; }

        private int _quantity;
        
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity must be more than 0!");
                _quantity = value;
            }
        }

        public string ProductInfo
        {
            get
            {
                return $"{Product.Name} ({Quantity} items)";
            }
        }
    }
}
