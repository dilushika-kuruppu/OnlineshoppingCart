using OnlineShopping.Common.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Product
{
   public interface IProductManager
    {

        Task<ProductDetailDto> GetProduct(int id); 
        Task<IEnumerable<ProductListDto>> GetProducts();
        Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int id);
        
    }
}
