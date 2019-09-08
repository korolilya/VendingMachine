
namespace Logic.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Logic.TerminalsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Logic.TerminalsDB context)
        {

            Product[] products =
            {
                new Product
                { Code= "AhFg",
                    Name ="Lays",
                    //SellingPrice =40,
                    //PurchasePrice =30
                     Prices = new List<ProductPrice>
                    {
                        new ProductPrice
                        {
                            SellingPrice = 40,
                            PurchasePrice = 30,
                            DateFrom = new DateTime(2017, 10, 3)
                        },
                        new ProductPrice
                        {
                            SellingPrice = 50,
                            PurchasePrice = 30,
                            DateFrom = new DateTime(2017, 11, 2)
                        },
                    }
                },

                new Product
                { Code= "FghY",
                    Name ="Coke",
                     Prices = new List<ProductPrice>
                    {
                        new ProductPrice
                        {
                            SellingPrice = 50,
                            PurchasePrice = 40,
                           DateFrom = new DateTime(2017, 10, 3)
                        },
                        new ProductPrice
                        {
                            SellingPrice = 50,
                            PurchasePrice = 30,
                            DateFrom = new DateTime(2017, 11, 4)
                        },
                    }
                },

                new Product
                { Code= "YYYY",
                    Name ="Dr.Pepper",
                     Prices = new List<ProductPrice>
                    {
                        new ProductPrice
                        {
                            SellingPrice = 55,
                            PurchasePrice = 40,
                            DateFrom = new DateTime(2017, 10, 3)
                        },
                        new ProductPrice
                        {
                            SellingPrice = 50,
                            PurchasePrice = 35,
                            DateFrom = new DateTime(2017, 11, 15)
                        },
                    }
                },

                new Product
                { Code= "OOPP",
                    Name ="Tuk",
                     Prices = new List<ProductPrice>
                    {
                        new ProductPrice
                        {
                            SellingPrice = 40,
                            PurchasePrice = 30,
                            DateFrom = new DateTime(2017, 10, 3)
                        },
                        new ProductPrice
                        {
                            SellingPrice = 45,
                            PurchasePrice = 30,
                            DateFrom = new DateTime(2017, 11, 19)
                        },
                    }
                },

                new Product
                { Code= "BBBB",
                    Name ="Pringles",
                     Prices = new List<ProductPrice>
                    {
                        new ProductPrice
                        {
                            SellingPrice = 130,
                            PurchasePrice = 100,
                            DateFrom = new DateTime(2017, 10, 3)
                        },
                        new ProductPrice
                        {
                            SellingPrice = 150,
                            PurchasePrice = 100,
                            DateFrom = new DateTime(2017, 11, 26)
                        },
                    }
                },

                new Product
                { Code= "FFFF",
                    Name ="Fanta",
                     Prices = new List<ProductPrice>
                    {
                        new ProductPrice
                        {
                            SellingPrice = 50,
                            PurchasePrice = 40,
                            DateFrom = new DateTime(2017, 10, 3)
                        },
                        new ProductPrice
                        {
                            SellingPrice = 50,
                            PurchasePrice = 45,
                            DateFrom = new DateTime(2017, 11, 13)
                        },
                    }
                }
            };

            Money[] cash =
            {
                new Money{Value=1, Quantity=100},
                new Money{Value=2, Quantity=50},
                new Money{Value=5, Quantity=100},
                new Money{Value=10, Quantity=100}
            };

            VMachine[] vmachines =
            {
                new VMachine
                {
                    Location ="Moscow",

                    Money= cash.ToList(),
                     DailyStatistics = new List<DailyStatistic>
                     {
                        new DailyStatistic
                        {
                            Product = products[0],
                            Quantity = 5,
                            Date = new DateTime(2017, 11, 11)
                        },
                        new DailyStatistic
                        {
                            Product = products[4],
                            Quantity = 8,
                            Date = new DateTime(2017, 10, 5)
                        }
                     },
                    Products= new List<FilledVM>
                    {
                     new FilledVM
                     {
                        Product=products[0],
                        Quantity = 10
                     },
                     new FilledVM
                     {
                        Product=products[4],
                        Quantity = 10
                     },
                     new FilledVM
                     {
                        Product=products[3],
                        Quantity = 0
                     }
                    }
                },
                 new VMachine
                {
                    Location ="Toronto",

                    Money= cash.ToList(),
                     Products= new List<FilledVM>
                    {
                     new FilledVM
                     {
                        Product=products[1],
                        Quantity = 10
                     },
                     new FilledVM
                     {
                        Product=products[2],
                        Quantity = 5
                     },
                     new FilledVM
                     {
                        Product=products[5],
                        Quantity = 8
                     },
                     new FilledVM
                     {
                        Product=products[3],
                        Quantity = 0
                     }

                    },
                     DailyStatistics = new List<DailyStatistic>
                     {
                        new DailyStatistic
                        {
                            Product = products[1],
                            Quantity = 5,
                            Date = new DateTime(2017, 10, 25)
                        },
                        new DailyStatistic
                        {
                            Product = products[2],
                            Quantity = 2,
                            Date = new DateTime(2017, 11, 10)
                        },
                        new DailyStatistic
                        {
                            Product = products[5],
                            Quantity = 2,
                            Date = new DateTime(2017, 10, 30)
                        }
                     }


                  }
            };



            context.Products.AddOrUpdate(
               p => p.Name,
               products
           );
            context.Money.AddOrUpdate(
              c => c.Value,
              cash
          );

            context.VMachines.AddOrUpdate(
              v => v.Location,
              vmachines
          );







        }
    }
}




