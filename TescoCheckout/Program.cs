using System;
using System.Collections.Generic;
using System.Linq;

namespace TescoCheckout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tesco CheckOut Started");
            var productList = GetProducts();
            var checkoutList = new List<CheckOut>();
            Console.WriteLine("Please add iteams and type 'end' for checkout");
            Console.WriteLine();
            while (true)
            {
                var productId = Console.ReadLine()?.ToUpper();
                if (productId == "END")
                {
                    Console.WriteLine();
                    Console.WriteLine("Added Product details");
                    foreach (var checkout in checkoutList)
                    {
                        Console.WriteLine($"Product {checkout.Product.Name}, Description {checkout.Product.Description}, Quantity {checkout.Quantity}, Final Price \u00A3{checkout.FinalPrice}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"Total items : {checkoutList.Sum(x => x.Quantity)} , Total Amount : \u00A3{checkoutList.Sum(x => x.FinalPrice)}");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine();
                    break;
                }
                var product = productList.FirstOrDefault(x => x.Id == productId);
                if (product == null)
                {
                    Console.WriteLine("Product not found. Please try again.");
                    continue;
                }
                var item = checkoutList.FirstOrDefault(x => x.Product.Id == productId);
                if(item == null)
                {
                    checkoutList.Add(new CheckOut
                    {
                        Product = product,
                        Quantity = 1,
                        FinalPrice = product.Price
                    });
                }
                else
                {
                    item.Quantity += 1;
                    var specialPrice = item.Product.SpecialPrices.FirstOrDefault(x => x.NumberOfUnit == item.Quantity);
                    if (specialPrice != null)
                    {
                        item.FinalPrice = specialPrice.Price;
                    }
                    else
                    {
                        item.FinalPrice += item.Product.Price;
                    }
                }
                Console.WriteLine($"Product added {product.Name}, Description {product.Description}, Price \u00A3{product.Price}");
                Console.WriteLine();
            }
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id ="A",
                    Name ="A",
                    Description = "Iteam 1",
                    Price = (decimal)0.20,
                    SpecialPrices = new List<SpecialPrice>
                    {
                        new SpecialPrice
                        {
                            NumberOfUnit = 2,
                            Price = (decimal)0.35
                        }
                    }
                },
                new Product
                {
                    Id ="B",
                    Name ="B",
                    Description = "Iteam 2",
                    Price = (decimal)0.30,
                    SpecialPrices = new List<SpecialPrice>
                    {
                        new SpecialPrice
                        {
                            NumberOfUnit = 3,
                            Price = (decimal)0.70
                        }
                    }
                },
                new Product
                {
                    Id ="C",
                    Name ="C",
                    Description = "Iteam 3",
                    Price = (decimal)1.20,
                    SpecialPrices = new List<SpecialPrice>
                    {
                        new SpecialPrice
                        {
                            NumberOfUnit = 2,
                            Price = (decimal)2.00
                        },
                        new SpecialPrice
                        {
                            NumberOfUnit = 3,
                            Price = (decimal)2.75
                        }
                    }
                },
                new Product
                {
                    Id ="D",
                    Name ="D",
                    Description = "Iteam 4",
                    Price = (decimal)0.70
                },
                new Product
                {
                    Id ="E",
                    Name ="E",
                    Description = "Iteam 5",
                    Price = (decimal)0.45,
                    SpecialPrices = new List<SpecialPrice>
                    {
                        new SpecialPrice
                        {
                            NumberOfUnit = 3,
                            Price = (decimal)0.70
                        }
                    }
                },
            };
        }
    
    }
}
