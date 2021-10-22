using Remediation.Factory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Factory
{
   public class PizzaHut : IPizza
    {
        public IBaseTomate GetTomatePizza()
        {
            return new PizzaReine();
        }

        public IBaseCreme GetCremePizza()
        {
            return new PizzaSavoyarde();
        }
    }
}
