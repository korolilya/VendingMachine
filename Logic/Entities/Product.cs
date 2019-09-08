using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Product
    {
       
        [Key]
        [StringLength(4)]

        public string Code { get; set; }
        public string Name { get; set; }
        public List<ProductPrice> Prices { get; set; }
        public ProductPrice LastPrice => Prices.Last(pp => pp.DateFrom <= DateTime.Today);
        public string Info
        {
            get
            {
                return string.Join("-", Code, Name,"Purchase price:" + LastPrice.PurchasePrice + "₽", "Selling price:" + LastPrice.SellingPrice + "₽");
            }
        }
    }
}

