using GDR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Helpers
{
    public class ChainTriagem : AbstractHandlerOrders
    {
        public override object Handle(object[] request)
        {
            if ((request[0] as String).Equals("triagem") && (request[1] == null ? false : true))
            {
                Order order = request[2] as Order;
                order.Queue = Enumerators.Queue.Triagem;
                order.Request.Status = Enumerators.Status.Triagem;

                return order;
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
