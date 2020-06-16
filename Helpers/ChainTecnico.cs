using GDR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Helpers
{
    public class ChainTecnico : AbstractHandlerOrders
    {
        public override object Handle(object[] request)
        {
            if ((request[0] as String).Equals("fechar") && (request[1] == null ? false : true))
            {
                Order order = request[2] as Order;
                order.Queue = Enumerators.Queue.Requisitante;
                order.Request.Status = Enumerators.Status.Fechado;
                order.Request.User = order.User;

                return order;
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
