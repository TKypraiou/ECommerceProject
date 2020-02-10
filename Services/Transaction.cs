using ECommerceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.Services
{
    public class Transaction
    {
        public void CreateData()
        {
            using EcommerceDbContent db = new EcommerceDbContent();

            db.Customers.AddRange(
                new List<Customer>
                {
                    new Customer
                    {
                        Name = "Eleana",
                        Address = "Athina",
                        Balance = 100,
                        RegistrationDate = new DateTime()
                    },
                    new Customer
                    {
                        Name = "Dimitra",
                        Address = "Athina",
                        Balance = 120,
                        RegistrationDate = new DateTime()
                    },
                    new Customer
                    {
                        Name = "Theodora",
                        Address = "Athina",
                        Balance = 98,
                        RegistrationDate = new DateTime()
                    },
                }
            );

            db.Products.AddRange(
                new List<Product>
                {
                    new Product
                    {
                        Name = "car",
                        Price = 99,
                        StockQuantity = 4
                    },
                    new Product
                    {
                        Name = "yacht",
                        Price = 29,
                        StockQuantity = 20
                    },
                    new Product
                    {
                        Name = "iphone",
                        Price = 39,
                        StockQuantity = 2
                    },
                    new Product
                    {
                        Name = "drone",
                        Price = 133,
                        StockQuantity = 2
                    },
                }
            );

            db.SaveChanges();
        }

        public void DoSale()
        {
            using EcommerceDbContent db = new EcommerceDbContent();
            Customer c = db.Customers.Find(1);
            Product p1 = db.Products.Find(2);
            Product p2 = db.Products.Find(4);

            Order order = new Order
            {
                Customer = c,
                Date = new DateTime(),
            };
            OrderProduct op = new OrderProduct
            {
                Order = order,
                OrderQuantity = 2,
                Product = p1
            };
            OrderProduct op2 = new OrderProduct
            {
                Order = order,
                OrderQuantity = 3,
                Product = p2
            };

            db.OrderProducts.Add(op);
            db.OrderProducts.Add(op2);
            db.SaveChanges();
        }
    }
}
