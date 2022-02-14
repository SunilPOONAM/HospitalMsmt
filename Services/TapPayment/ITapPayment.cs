using System;
using System.Collections.Generic;
using System.Text;

namespace Services.TapPayment
{
    public interface ITapPayment
    {
        string ChargeCard(RootObject model);
        string RetrieveChargeDetail(string charge_id);
    }
}
