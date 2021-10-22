using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remediation.Injection
{
    public class Singleton
    {
        private static Singleton instance = null;
        private static object TheObject = null;

        public Singleton()
        {
        }

        public Singleton Instance(object obj)
        {
            {
                if (instance == null)
                {
                    instance = new Singleton();
                    TheObject = obj;
                }
                return instance;
            }
        }
        public object Get()
        {
                return TheObject;
        }
    }
}
