using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Factory.Products
{
    class PizzaSavoyarde : IBaseCreme
    {
        public string GetIngredients()
        {
            return "Mozzarella, Lardons fumés, Pommes de terre françaises sautées, Reblochon de Savoie AOP, Origan";
        }
    }
}
