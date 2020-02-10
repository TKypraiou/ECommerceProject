using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Dto;
using ECommerceProject.Models;
using ECommerceProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerceProject.Controllers
{
    [ApiController]
    [Route("")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("e-shop")]
        public string ShowInfo()
        {
            return "Welcome to our e-shop!!";
        }

        [HttpGet("customers")]
        public List<Customer> GetCustomers()
        {
            CustomerServices cs = new CustomerServices();
            return cs.GetCustomers(20);
        }

        [HttpGet("customerById/{customerId}")]
        public ReturnData<Customer> GetCustomerById([FromRoute] int customerId)
        {
            CustomerServices cs = new CustomerServices();
            return cs.GetCustomerById(customerId);
        }

        [HttpGet("customerByName/{customerNme}")]
        public ReturnData<List<Customer>> GetCustomerByName([FromRoute] string customerNme)
        {
            CustomerServices cs = new CustomerServices();
            return cs.GetCustomerByName(customerNme);
        }

        [HttpGet("products")]
        public List<Product> GetProducts()
        {
            CustomerServices cs = new CustomerServices();
            return cs.GetProducts(20);
        }

        [HttpGet("productById/{productId}")]
        public ReturnData<Product> GetProductById([FromRoute] int productId)
        {
            CustomerServices cs = new CustomerServices();
            return cs.GetProductById(productId);
        }

        [HttpGet("productByName/{productName}")]
        public ReturnData<List<Product>> GetProductByName([FromRoute] string productName)
        {
            CustomerServices cs = new CustomerServices();
            return cs.GetProductByName(productName);
        }

        [HttpGet("ordersByCustomerId/{customerId}")]
        public ReturnData<Order> GetOrdersByCustomerId(int customerId)
        {
            CustomerServices cs = new CustomerServices();
            return cs.GetOrdersByCustomerId(customerId);
        }

        [HttpGet("customerId/{customerId}/orderId/{orderId}")]
        public ReturnData<Order> GetOrderByCustomerId(int customerId, int orderId)
        {
            CustomerServices cs = new CustomerServices();
            return cs.GetOrderByCustomerId(customerId, orderId);
        }

        [HttpPut("customerById/{customerId}")]
        public ReturnData<Customer> UpdateCustomerById(
            [FromRoute] int customerId, [FromBody] CustomerDto customerDto)
        {
            CustomerServices cs = new CustomerServices();
            return cs.UpdateCustomerById(customerId, customerDto);
        }

        [HttpPost("customer")]
        public Customer CreateCustomer([FromBody] CustomerDto customerDto)
        {
            CustomerServices cs = new CustomerServices();
            return cs.CreateCustomer(customerDto);
        }

        [HttpPost("product")]
        public Product CreateProduct([FromBody]ProductDto productDto)
        {
            CustomerServices cs = new CustomerServices();
            return cs.CreateProduct(productDto);
        }

        /*[HttpPost("customerById/{customerId}/order")]
        public ReturnData<List<Order>> CreateOrder(int customerId, [FromBody] OrderDto orderDto) 
        {
            CustomerServices cs = new CustomerServices();
            return cs.CreateOrder(orderDto);
        }*/
    }
}
