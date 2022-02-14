using Services.PayTab;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PayTab
{
    public interface IPayTabAPI
    {
        string CreatePayPage(PayPageRequest objPayPageRequest);

        string MakeWebServiceCall(string methodCall, string formContent);

        VerifyPaymentResponse VerifyPayment(VerifyPaymentRequest objPaymentRequest);
    }
}
