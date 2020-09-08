
using OnlineShopping.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Data.Repository
{
    public interface IUnitofWork
    {
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IProductRepository ProductRepository { get; }
        IAuthRepository AuthRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IPaymentRepository PaymentRepository { get; }

        void Commit();
        void Rollback();
    }
}
