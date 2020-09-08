using System;
using OnlineShopping.Common.CategoryDto;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Category
{
    public interface ICategoryManager
    {
        Task<IEnumerable<CategoryForDetailDto>> GetCategory();
    }
}
