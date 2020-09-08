using OnlineShopping.Common.PaymentDto;
using OnlineShopping.Data.Models;
using OnlineShopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.PaymentManager
{
    public class PaymentManager : IPaymentManager

    {
        private readonly IUnitofWork _unitofWork;
   
        /// <summary>Initializes a new instance of the <see cref="PaymentManager" /> class.</summary>
        /// <param name="paymentRepository">The payment repository.</param>
   
        /// <param name="mapper">The mapper.</param>
        public PaymentManager(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
         
        }

        public async Task<Payment> CreateOrUpdatePayment(PaymentDto paymentDto)
        {
            try
            {
                await _unitofWork.PaymentRepository.CreateOrUpdatePayment(paymentDto);
                _unitofWork.Commit();

                return null;

            }
            catch (Exception e)
            {
                _unitofWork.Rollback();
                return null;
            }
        }
        //public async Task<bool> DeletePayment(int id)
        //{
        //    PaymentDto payment = await _unitofWork.PaymentRepository.CreateOrUpdatePayment(id);

        //    if (payment == null)
        //        return false;

        //    _unitofWork.PaymentRepository.Delete(payment);
        //    return await _unitofWork.PaymentRepository.SaveAll();
        //}

    }
}

