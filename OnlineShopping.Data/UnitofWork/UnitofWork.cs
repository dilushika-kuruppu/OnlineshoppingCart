using AutoMapper;
using OnlineShopping.Data.Context;
using OnlineShopping.Data.Models;
using OnlineShopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Data.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly OnlineShoppingContext _context;
        private readonly IMapper _mapper;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IProductRepository _productRepository;
        private IAuthRepository _authRepository;
        private ICategoryRepository _categoryRepository;
        private IPaymentRepository _paymentRepository;


        public UnitofWork(OnlineShoppingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IOrderRepository OrderRepository
        { get { return _orderRepository = _orderRepository ?? new OrderRepository(_context, _mapper); } }


        public IOrderItemRepository OrderItemRepository
        { get { return _orderItemRepository = _orderItemRepository ?? new OrderItemRepository(_context, _mapper); } }

        public IProductRepository ProductRepository
        { get { return _productRepository = _productRepository ?? new ProductRepository(_context, _mapper); } }

        public IAuthRepository AuthRepository
        { get { return _authRepository = _authRepository ?? new AuthRepository(_context, _mapper); } }

        public ICategoryRepository CategoryRepository
        { get { return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context, _mapper); } }

        public IPaymentRepository PaymentRepository
        { get { return _paymentRepository =  _paymentRepository ?? new PaymentRepository(_context, _mapper); } }

        public void Commit()
        {
            _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.DisposeAsync();
        }
    }
}
