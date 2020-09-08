using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Business.Product;
using OnlineShopping.Common.ProductDto;
using OnlineShopping.Data.Models;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly OnlineShoppingContext _context;
        private readonly IProductManager _productBusinessLayer;

        public ProductsController(OnlineShoppingContext context, IProductManager productBusinessLayer)
        {
            _context = context;
            _productBusinessLayer = productBusinessLayer;
          
        }

        /// <summary>Gets the products.</summary>
        /// <returns></returns>
        [HttpGet]
       public async Task<IActionResult> GetProducts()
       {
          //gaeting data from db  
           var products = await _productBusinessLayer.GetProducts();
           return Ok(products);
      }

        /// <summary>Gets the product.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productDetail = await _productBusinessLayer.GetProduct(id);
            return Ok(productDetail);
        }

        /// <summary>Getcategoryproducts the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("category/{id}")]
        public async Task<IActionResult> Getcategoryproduct(int id)
        {
            var productbyCategory = await _productBusinessLayer.GetProductbyCategory(id);
            return Ok(productbyCategory);
        }


    }
}