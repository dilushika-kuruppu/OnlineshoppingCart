using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Common.ProductDto;
using OnlineShopping.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShoppingContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(OnlineShoppingContext context, IMapper mapper)
        {
            _context = context;
           _mapper = mapper;
        }
        /// <summary>Adds the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        /// <summary>Deletes the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        /// <summary>Gets the product.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ProductDetailDto> GetProduct(int id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(i => i.Id == id);
           
            return _mapper.Map<ProductDetailDto>(product);
        }

        /// <summary>Gets the products.</summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductListDto>> GetProducts()

        {
            //var products = await _context.Product.ToListAsync();
            //return _mapper.Map<ProductListDto[]>(products);
            var products = await (from category in _context.Category
                                  join
                                    product in _context.Product on category.Id equals product.CategoryId
                                  where product.CategoryId == category.Id
                                  select new ProductListDto()
                                  {
                                      Id = product.Id,
                                      CategoryId = product.CategoryId,
                                      Name = product.Name,
                                      Description = product.Description,
                                      Price = product.Price,


                                  }).ToListAsync();

            return products;
        }

        /// <summary>Saves all.</summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>Gets the productby category.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int id)
        {
            var products = await (from category in _context.Category
                                  join
                                    product in _context.Product on category.Id equals product.CategoryId
                                  where product.CategoryId == id
                                  select new ProductDetailDto()
                                  {
                                      Id = product.Id,
                                      CategoryId = product.CategoryId,
                                      Name = product.Name,
                                      Description = product.Description,
                                      Price = product.Price,


                                  }).ToListAsync();
            return products;
        }

    }
}

