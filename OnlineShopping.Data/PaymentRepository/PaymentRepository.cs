using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Common.PaymentDto;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly OnlineShoppingContext _context;
        private readonly IMapper _mapper;
      
        public PaymentRepository(OnlineShoppingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

     

        public async Task<PaymentDto> CreateOrUpdatePayment(PaymentDto paymentDto)
        {

            Payment payment = _mapper.Map<PaymentDto, Payment>(paymentDto);
            await _context.Payment.AddAsync(payment);
            await _context.SaveChangesAsync();

            return paymentDto;
        }

        public async Task<PaymentDto> CheckPaymentStatus(int orderId)
        {
            Payment payment = await _context.Payment.Where(s => s.Id == orderId).FirstOrDefaultAsync();

            PaymentDto paymentDto = _mapper.Map<Payment, PaymentDto>(payment);

            return paymentDto;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
