using GDR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Helpers
{
    public class ChainSuporte : AbstractHandlerOrders
    {
        public override object Handle(object[] request)
        {
            if ((request[0] as String).Equals("n2") && (request[1] == null ? false : true))
            {
                Order order = request[2] as Order;
                User user = request[3] as User;
                order.Request.Scheduling = DateTime.Now.AddDays(7);
                order.Queue = Enumerators.Queue.nivel2;
                order.Request.Status = Enumerators.Status.Suporte;
                order.Request.User = user;

                return order;
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
