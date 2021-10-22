using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Factory.Products
{
    class Pizza4Fromages : IBaseCreme
    {
        //Techniquement la pizza 4 fromages est une base tomate mais bon, hein oh
        public string GetIngredients()
        {
            return "Mozzarella, chèvre, emmental français, Fourme d’Ambert AOP";
        }
    }
}
