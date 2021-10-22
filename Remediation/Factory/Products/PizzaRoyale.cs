using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Factory.Products
{
    class PizzaRoyale : IBaseTomate
    {
        public string GetIngredients()
        {
            return "Mozzarella, Jambon, Olives, Oignon, Basilic et Champignons.";
        }
    }
}
