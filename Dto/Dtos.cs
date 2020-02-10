using ECommerceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.Dto
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    public class OrderDto
    {
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
    }
}
