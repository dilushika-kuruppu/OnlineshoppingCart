using OnlineShopping.Common.PaymentDto;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.PaymentManager
{
    public interface IPaymentManager
    {
        Task<Payment> CreateOrUpdatePayment(PaymentDto paymentDto);
    }
}
