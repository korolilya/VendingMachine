using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public double SellingPrice { get; set; }
        public double PurchasePrice { get; set; }
        public double Profit => SellingPrice - PurchasePrice;
        public string PriceInfo
        {
            get
            {
                return $"Selling price:{SellingPrice}₽ and purchase price:{PurchasePrice}";
            }
        }
    }
}
