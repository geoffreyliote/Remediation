using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Injection
{
   public class Transient
    {
        private static object TheObject;

        public Transient()
        {
        }

        public void Instance(object obj)
        {
                    TheObject = obj;
        }
        public object Get()
        {
            var e = (TheObject.GetType()).GetConstructors().First();
            TheObject = e.Invoke(null);
            return TheObject;
        }
    }
}
