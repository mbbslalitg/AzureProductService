using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Models;

namespace ProductService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private AppDbContext _appDbcontext;
        public ProductController(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_appDbcontext.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _appDbcontext.Products
                               .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            return Ok(product);
        }

        

        [HttpPost]
        public IActionResult AddProducts(Product product)
        {
            _appDbcontext.Products.Add(product);
            _appDbcontext.SaveChanges();
            return Ok(product);
        }
    }
}