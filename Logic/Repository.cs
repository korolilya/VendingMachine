using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace Logic
{
    public class Repository
    {
        public event Action<Product> ProductsChanged;
        public event Action<VMachine> VMChanged;



        public IEnumerable<VMachine> VMachines
        {
            get
            {
                using (var context = new TerminalsDB())
                    return context.VMachines
                        .Include(t => t.Money)
                        .Include(t => t.Products.Select(p => p.Product))
                        .ToList();
            }
        }


        public IEnumerable<Product> Products
        {
            get
            {
                using (var context = new TerminalsDB())
                    return context.Products
                        .Include(p => p.Prices).ToList();
            }
        }

        public void AddProduct(Product product, string code, string newName, double pp, double sp)
        {
            using (var context = new TerminalsDB())
            {
                if
                    (context.Products.Find(product.Code) == null ||
                    context.Products.Find(product.Name) == null)
                {                   
                    product = new Product
                    {
                        Code = code,
                        Name = newName,
                        Prices = new List<ProductPrice>
                {
                 new ProductPrice
                 {
                    SellingPrice= sp,
                    PurchasePrice= pp,
                    DateFrom=DateTime.Today
                 }
                }
                    };

                    context.Products.Add(product);
                    context.SaveChanges();
                    ProductsChanged?.Invoke(product);
                }

            }
        }

        public void DeleteProduct(Product product)
        {
            using (var context = new TerminalsDB())
            {
                if (context.VMachines.Any(vm => vm.Products.Any(p => p.Product.Code == product.Code)))
                    throw new Exception("This product cannot be deleted beacuse it is included into Terminal!");
                var deletedProduct = context.Products.Include(p => p.Prices).First(p => p.Code == product.Code);
                deletedProduct.Prices.Clear();
                context.Products.Remove(deletedProduct);
                context.SaveChanges();
            }
        }

        public void EditProduct(Product product, string newName)
        {
            using (var context = new TerminalsDB())
            {
                DateTime dt = DateTime.Today.AddDays(1);
                var prodFromDB = context.Products.Find(product.Code);
                prodFromDB.Name = newName;
                context.SaveChanges();
                ProductsChanged?.Invoke(prodFromDB);
            }
        }

        public void EditPrice(Product product, double sp, double pp, DateTime dt)
        {
            using (var context = new TerminalsDB())
            {
                var prodFromDB = context.Products.Find(product.Code);
                if (product.LastPrice.SellingPrice != sp && product.LastPrice.PurchasePrice != pp)
                {                    
                    prodFromDB.Prices = new List<ProductPrice>
                {
                    new ProductPrice
                    {
                     PurchasePrice=pp,
                     SellingPrice=sp,
                     DateFrom=dt
                     }
                  };
                    context.SaveChanges();
                    ProductsChanged?.Invoke(prodFromDB);
                }
            }
        }

        public void EditTerminal(VMachine vMachine, string newLocation)
        {
            using (var context = new TerminalsDB())
            {
                var terminalFromDB = context.VMachines.Find(vMachine.Id);
                terminalFromDB.Location = newLocation;
                context.SaveChanges();
                VMChanged?.Invoke(terminalFromDB);
            }
        }

        public void AddTerminal(string location)
        {
            using (var context = new TerminalsDB())
            {
                if (context.VMachines.Any(v => v.Location == location))
                    throw new Exception("Vending machine with this location already exists!");

                var vMachine = new VMachine { Location = location };
                vMachine.Money = DataForTerminal.GetMoney();
                context.VMachines.Add(vMachine);
                context.SaveChanges();
                VMChanged?.Invoke(vMachine);
            }
        }

        public IEnumerable<EmptyViewModel> EmptyTerminal
        {
            get
            {
                return (from v in VMachines
                        where v.Products.Any(p => p.Quantity == 0)
                        select new EmptyViewModel
                        {
                            Location = v.Location,
                            MissingProducts = v.Products.Where(p => p.Quantity == 0).Select(p => p.Product)
                        }).ToList();
            }
        }



        public IEnumerable<ProfitViewModel> ProfitableTerminal(int year, int month)
        {
            return VMachines.Select(v => new ProfitViewModel
            {
                Location = v.Location,
                Profit = v.DailyStatistics
                .Where(d => d.Date.Month == month && d.Date.Year == year)
                .Sum(d => d.Quantity * d.Product.Prices.Where(pp => d.Date >= pp.DateFrom).Last().Profit)
            }).ToList();
        }

        public IEnumerable<UnpopularProdViewModel> UnpopularProducts(int year, int month)
        {
            using (var context = new TerminalsDB())
            {
                return context.DailyStatistics
                    .Where(d => d.Date.Month == month && d.Date.Year == year)
                    .GroupBy(d => d.Product)
                    .Select(g => new UnpopularProdViewModel
                    {
                        Name = g.Key.Name,
                        QuantitySold = g.Sum(p => p.Quantity)
                    })
                    .OrderBy(p => p.QuantitySold)
                    .ToList().Take(5);
            }
        }
    }
}

