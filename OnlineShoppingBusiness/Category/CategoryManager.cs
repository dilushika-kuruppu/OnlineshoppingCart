using AutoMapper;
using OnlineShopping.Business.Category;
using OnlineShopping.Common.CategoryDto;
using OnlineShopping.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Category
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitofWork _unitofWork;

        public CategoryManager(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        /// <summary>Gets the category.</summary>
        /// <returns></returns>
        async Task<IEnumerable<CategoryForDetailDto>> ICategoryManager.GetCategory()
        {
            return await _unitofWork.CategoryRepository.GetCategory();
            
        }

       
    }
}

