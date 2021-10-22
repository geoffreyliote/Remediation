using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Factory.Products
{
    class PizzaReine : IBaseTomate
    {
        public string GetIngredients()
        {
            return "Mozzarella, Jambon et Champignons.";
        }
    }
}
