using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Business.Category;
using OnlineShopping.Data.Repository;

namespace OnlineShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryManager _categoryBusinessLayer;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryManager categoryBusinessLayer, ICategoryRepository categoryRepository, IMapper mapper)
        {

            _categoryBusinessLayer = categoryBusinessLayer;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        /// <summary>Gets the categorties.</summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategorties()
        {
            var categories = await _categoryBusinessLayer.GetCategory();
            return Ok(categories);
        }
    }
}
