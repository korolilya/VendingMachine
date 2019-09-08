using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class EmptyViewModel
    {
        public string Location { get; set; }
        public IEnumerable<Product> MissingProducts { get; set; }

        public string Info
        {
            get
            {
                string missingProductsName = string.Join(", ", MissingProducts.Select(p => p.Name));
                return $"{Location} - missing: {missingProductsName}";
            }
        }
    }
}
