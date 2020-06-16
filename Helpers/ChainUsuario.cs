using GDR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Helpers
{
    public class ChainUsuario : AbstractHandlerOrders
    {
        public override object Handle(object[] request)
        {
            if ((request[0] as String).Equals("usuario") && (request[1] == null ? false : true))
            {
                User user = request[3] as User;
                Order order = request[2] as Order;
                order.Queue = Enumerators.Queue.Requisitante;
                order.Request.Status = Enumerators.Status.Atualizado;
                order.Request.User = user;

                return order;
            }else
            {
                return base.Handle(request);
            }
        }
    }
}
