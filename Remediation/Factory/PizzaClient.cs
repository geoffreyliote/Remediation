using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Factory
{
   public class PizzaClient
    {
        IBaseTomate baseTomate;
        IBaseCreme baseCreme;

        public PizzaClient(IPizza factory)
        {
            baseTomate = factory.GetTomatePizza();
            baseCreme = factory.GetCremePizza();
        }

        public string GetBaseTomateIngredient()
        {
            return baseTomate.GetIngredients();
        }

        public string GetBaseCremeIngredient()
        {
            return baseCreme.GetIngredients();
        }
    }
}
