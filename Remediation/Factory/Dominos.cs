using Remediation.Factory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Factory
{
   public class Dominos : IPizza
    {
        public IBaseTomate GetTomatePizza()
        {
            return new PizzaRoyale();
        }

        public IBaseCreme GetCremePizza()
        {
            return new Pizza4Fromages();
        }
    }
}  
