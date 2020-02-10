using ECommerceProject.Dto;
using ECommerceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.Services
{
    public class CustomerServices
    {
        public Customer Customer { set; get; }

        public List<Customer> GetCustomers(int howMany)
        {
            List<Customer> customers;
            using EcommerceDbContent db = new EcommerceDbContent();
            customers = db.Customers
                .Take(howMany)
                .ToList();
            return customers;
        }

        public ReturnData<Customer> GetCustomerById(int customerId)
        {
            using EcommerceDbContent db = new EcommerceDbContent();
            Customer customer = db.Customers.Find(customerId);
            return new ReturnData<Customer>
            {
                Data = customer,
                Error = (customer == null) ? 1 : 0,
                Description = (customer == null) ? "No such customer Id = "
                + customerId : "Ok"
            };
        }

        public ReturnData<List<Customer>> GetCustomerByName(string customerName)
        {
            using EcommerceDbContent db = new EcommerceDbContent();
            List<Customer> customers = db.Customers
                .Where(n => n.Name.StartsWith(customerName)).ToList();
            return new ReturnData<List<Customer>>
            {
                Data = customers,
                Error = (customers == null) ? 1 : 0,
                Description = (customers == null) ? "No such customer name = "
                + customerName : "Ok"
            };
        }

        public List<Product> GetProducts(int howMany)
        {
            List<Product> products;
            using EcommerceDbContent db = new EcommerceDbContent();
            products = db.Products
                .Take(howMany)
                .ToList();
            return products;
        }

        public ReturnData<Product> GetProductById(int ProductId)
        {
            using EcommerceDbContent db = new EcommerceDbContent();
            Product product = db.Products.Find(ProductId);
            return new ReturnData<Product>
            {
                Data = product,
                Error = (product == null) ? 1 : 0,
                Description = (product == null) ? "No such product Id = "
                + ProductId : "Ok"
            };
        }

        public ReturnData<List<Product>> GetProductByName(string productName)
        {
            using EcommerceDbContent db = new EcommerceDbContent();
            List<Product> product = db.Products
                .Where(n => n.Name.StartsWith(productName)).ToList();
            return new ReturnData<List<Product>>
            {
                Data = product,
                Error = (product == null) ? 1 : 0,
                Description = (product == null) ? "No such product name = "
                + productName : "Ok"
            };
        }

        public ReturnData<Order> GetOrdersByCustomerId(int customerId)
        {
            using EcommerceDbContent db = new EcommerceDbContent();
            Order order = db.Orders.Find(customerId);
            return new ReturnData<Order>
            {
                Data = order,
                Error = (order == null) ? 1 : 0,
                Description = (order == null) ? "No such customer Id = "
                + customerId : "Ok"
            };
        }

        public ReturnData<Order> GetOrderByCustomerId(int customerId, int orderId)
        {
            using EcommerceDbContent db = new EcommerceDbContent();
            List<Order> order = db.Orders
                .Where(c => c.CustomerId.Equals(customerId)).ToList();
            order = db.Orders
                .Where(o => o.Id.Equals(orderId)).ToList();
            return new ReturnData<Order>
            {
                Error = (order == null) ? 1 : 0,
                Description = (order == null) ? "No such order Id = "
                + customerId : "Ok"
            };
        }

        public ReturnData<Customer> UpdateCustomerById(int customerId, CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return new ReturnData<Customer>
                {
                    Error = 1001,
                    Description = "No data were given"
                };
            }

            using EcommerceDbContent db = new EcommerceDbContent();
            Customer customer = db.Customers.Find(customerId);

            if (customer == null)
            {
                return new ReturnData<Customer>
                {
                    Error = 1002,
                    Description = "No such customer Id"
                };
            }

            if (customerDto.Address != null)
                customer.Address = customerDto.Address;
            if (customerDto.Name != null)
                customer.Name = customerDto.Name;

            db.SaveChanges();
            return new ReturnData<Customer>
            {
                Data = customer,
                Error = 0,
                Description = "No errors"
            };
        }

        public Customer CreateCustomer(CustomerDto customerDto)
        {
            Customer c = new Customer
            {
                Name = customerDto.Name,
                Address = customerDto.Address,
            };

            using EcommerceDbContent db = new EcommerceDbContent();
            db.Customers.Add(c);
            db.SaveChanges();
            return c;
        }

        public Product CreateProduct(ProductDto productDto) 
        {
            Product p = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity
            };

            using EcommerceDbContent db = new EcommerceDbContent();
            db.Products.Add(p);
            db.SaveChanges();
            return p;
        }

        /*public ReturnData<List<Order>> CreateOrder(int customerId, OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return new ReturnData<List<Order>>
                {
                    Error = 1001,
                    Description = "No data were given"
                };
            }

            using EcommerceDbContent db = new EcommerceDbContent();
            Order customer = db.Orders.Find(customerId);

            if (customer == null)
            {
                return new ReturnData<List<Order>>
                {
                    Error = 1002,
                    Description = "No such customer Id"
                };
            }

            Order o = new Order
            {
                CustomerId = orderDto.CustomerId,
                Customer = orderDto.Customer,
                Date = orderDto.Date
            };

            db.Orders.Add(o);
            db.SaveChanges();
            return o;
        }*/
    }
}
