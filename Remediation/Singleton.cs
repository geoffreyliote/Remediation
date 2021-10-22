using System;

namespace Remediation
{
    public class Singleton
    {
        private static Singleton instance = null;

        public Singleton()
        {
        }

        public Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public bool test()
        {
            if(instance == null)
            {

            return false;
            }
            else
            {
                return true;
            }
        }
    }
}
