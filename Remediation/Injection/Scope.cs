using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Injection
{
    public class Scope
    {
        private static Dictionary<Scope, object> KeyValues = new Dictionary<Scope, object>();
        private static object TheObject;

        public Scope()
        {
        }

        public void Instance(object obj)
        {
                    TheObject = obj;
            KeyValues.Add(this, obj);
        }
        public object Get()
        {
            if(KeyValues.ContainsKey(this))
            {
                return KeyValues.GetValueOrDefault(this);
            }
            else
            {
                var obj = (TheObject.GetType()).GetConstructors().First();
                TheObject = obj.Invoke(null);
                KeyValues.Add(this, obj);
                return TheObject;
            }
        }
    }
}
