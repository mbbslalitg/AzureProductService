using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountService.Data;
using DiscountService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiscountService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
         private AppDbContext _appDbcontext;
        public DiscountController(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        [HttpGet]
        public IActionResult GetAllDiscountedProductList()
        {
            return Ok(_appDbcontext.Discounts.ToList());
        }

        [HttpPost]
        public IActionResult AddProductDiscount(Discount discount)
        {
            discount.FinalPrice = discount.OriginalPrice - (discount.OriginalPrice * discount.DiscountPercentage / 100);
            _appDbcontext.Discounts.Add(discount);
            _appDbcontext.SaveChanges();
            return Ok(discount);
        }
    }
}