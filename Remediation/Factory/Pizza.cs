using Remediation.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation
{
    /// <summary>  
    /// The 'AbstractFactory' interface.  
    /// </summary>  
   public interface IPizza
    {
        IBaseTomate GetTomatePizza();
        IBaseCreme GetCremePizza();
    }
}
