using OnlineShopping.Common.CategoryDto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using OnlineShopping.Data.Models;

namespace OnlineShopping.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnlineShoppingContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(OnlineShoppingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>Gets the category.</summary>
        /// <returns></returns>
        public async Task<IEnumerable<CategoryForDetailDto>> GetCategory()
        {

            var Categories = await (from category in _context.Category
                                    select new CategoryForDetailDto()
                                    {
                                        CategoryId = category.Id,
                                        CategoryName = category.Name

                                    }).Distinct().ToListAsync();

            return Categories;
        }

    }
}
