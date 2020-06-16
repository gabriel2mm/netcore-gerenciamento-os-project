using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDR.Contracts
{
    public interface IHandler
    {
        public IHandler SetNext(IHandler handler);
        public object Handle(object[] request);
    }
}
