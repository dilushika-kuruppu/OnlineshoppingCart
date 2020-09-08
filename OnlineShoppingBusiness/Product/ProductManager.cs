using AutoMapper;
using OnlineShopping.Common.ProductDto;
using OnlineShopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Product
{
    public class ProductManager : IProductManager
    {

        private readonly IUnitofWork _unitofWork;
        public ProductManager(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        /// <summary>Gets the product.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ProductDetailDto> GetProduct(int id)
        {
            return await _unitofWork.ProductRepository.GetProduct(id);

        }



        /// <summary>Gets the productby category.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int id)
        {
            var productbyCategory = await _unitofWork.ProductRepository.GetProductbyCategory(id);
            return productbyCategory;
        }

        public async Task<IEnumerable<ProductListDto>> GetProducts()
        {
            return await _unitofWork.ProductRepository.GetProducts();
        }
    }

}
    

