using OnlineShopping.Common.PaymentDto;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public interface IPaymentRepository
    {
        Task<PaymentDto> CreateOrUpdatePayment(PaymentDto paymentDto);
        Task<PaymentDto> CheckPaymentStatus(int orderId);
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        

    }
}
