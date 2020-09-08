using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Business.Email
{
   public  interface IEmail
    {
        void Send(string toAddress, string subject, string body, bool sendAsync = true);
    
}
}
